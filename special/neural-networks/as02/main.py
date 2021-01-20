import math
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
from matplotlib import gridspec

"""
The weights for each form (linear, quadratic, ...) are defined as a list and the format is as follows,
w_n * x^n + w_(n-1) * x^(n-1) + ... + w_1 * x + w_0 <- polynomial of n degree
the above weights (coefficients + constant) are in a python list as follows,
weights = [ w_n, w_(n-1), ..., w_1, w_0 ]
"""

class RegressionModel():

    """RegressionModel
    This class handles the creation of models
    """

    def __init__(self, input_size, degree, weights=None):
        """Initialize the RegressionModel

        Args:
            input_size (int): The number of inputs, no. of features
            degree (int): The degree of the polynomial that is needed to fit the data
            weights (list, optional): define the weights of the model, for example if for linear equations ax+b = y, define a and b. Defaults to None.
        """
        self.__input_size = input_size
        self.__degree = degree
        weight_count = input_size * degree + 1
        if not weights:
            weights = list(np.random.random(size=(weight_count)))
        self._updateWeights(weights)

    def _updateWeights(self, weights):
        """Update the weights in a secure manner

        Args:
            weights (list | np.Array): The updated weights
        """
        weight_count = self.__input_size * self.__degree + 1
        if not isinstance(weights, list):
            raise Exception("weights must be a list")
        if not len(weights) == weight_count:
            raise Exception("weights must be of length {}".format(weight_count))
        self.__weights = np.reshape(np.array(weights), (weight_count, 1))

    def getWeights(self):
        """Return the weights currently in the model

        Returns:
            weights np.Array: current weights
        """
        return self.__weights

    def _expandInput(self, X):
        """Expand the input array into the dimensions of the model

        Args:
            X (np.Array): The input array

        Raises:
            Exception: The input shape should be (n, input_size)

        Returns:
            np.Array: The expanded input array into the dimension

        Example:
            if the model has two variables (x, y) and the degree is 2. Then the
            model would be of form y = ax + bx^2 + cy + dy^2 + e. When getting the input for the model
            we would accept [x, y] and then we would need to expand it into a form [x, x^2, y, y^2, 1] to make it easier
            for vectorizing the calculations. 
        """
        x = np.zeros(shape=(len(X), self.__input_size * self.__degree + 1))
        X = np.array(X)
        if X.shape[1] != self.__input_size:
            raise Exception("input shape should be of (n,{})".format(self.__input_size))
        x[:,-1:] = np.ones(shape=(x.shape[0], 1))

        for i in range(self.__input_size):
            si = self.__degree * i
            ei = self.__degree * i + self.__degree
            y = np.zeros(shape=(x.shape[0], self.__degree))
            y[:,:] = np.reshape(X[:,i], (x.shape[0], 1))
            x[:,si:ei] = np.power(y, range(1, self.__degree+1))
        
        return x
    
    def predict(self, X):
        """calculate the value given by the model. n is the number of instances of inputs

        Args:
            X (np.Array): (n, input_size)

        Returns:
            np.Array: (n, 1) <- n: number of instances
        """
        x = self._expandInput(X)
        return np.matmul(x, self.__weights)

    def evaluate(self, X, y):
        """Calculate the error to the given target labels

        Args:
            X (np.Array): the input instances
            y (np.Array): the target instances

        Returns:
            float: the error as SSE
        """
        pred = self.predict(X)
        err = (y - pred) ** 2
        cost = np.sum(err) / float(len(err))
        return cost

    def gradientDescent(self, X, y):
        """Calculate the gradient and the mean squared error

        Args:
            X (np.Array): an array of (n x input_size) n being the number of samples
            y ([type]): an array of (n x 1) of target values

        Returns:
            (grad, mse): The gradient descent and the mean squared error
        """
        pred = self.predict(X)
        err = (y - pred)
        x = self._expandInput(X)
        mse = np.sum((err ** 2)) / len(X)
        grad = np.reshape(np.sum(-err * x, 0) / len(X), self.__weights.shape)
        return grad, mse

    def makeHistory(self):
        """Initialize internal history list
        """
        self.history = []

    def addHistory(self, epoch, val_loss, train_loss, weights, mini=None, sample_count=None):
        """Add a history entry, this is useful while training a model to keep the learning progress

        Args:
            epoch (int): The current epoch
            val_loss (float): The validation loss
            train_loss (float): The training loss
            weights (np.Array): The weights of the model at the moment
            mini (int, optional): Used when keeping history of stochastic and mini-batch gradient descents. Defaults to None.
            sample_count (int, optional): The number of samples or the number batches in the training set. Defaults to None.
        """
        e = epoch
        if mini is not None and sample_count is not None:
                e = epoch + ((mini - 1) / sample_count)
        self.history.append({
            "epoch": e,
            "val_loss": val_loss,
            "train_loss": train_loss,
            "weights": weights
        })
        print("Epoch: {} | Val_loss: {} | Train_loss: {}".format(e, val_loss, train_loss))

    def batchGradientDescent(self, x_train, y_train, x_test, y_test, lr=0.001, epochs=100, delta=0.1e-3):
        """Executes batch gradient descent

        Args:
            x_train (np.Array): a numpy array of dimension (n x input_size) n being the number of instances and input_size is the number of independent variables
            y_train (np.Array): a numpy array of dimension (n x 1) n being the number of instances, this contains the target training labels or values
            x_test (np.Array): same as x_train, but has the test data
            y_test (np.Array): same as y_train, but has the test data
            lr (float, optional): the learning rate. Defaults to 0.001.
            epochs (int, optional): the number of maximum epochs to execute. Defaults to 100.
            delta (float, optional): the minimum change needed in the weights to continue learning. Defaults to 0.1e-3.

        Returns:
            history: the collected history list
        """

        i = 0

        self.makeHistory()

        for i in range(epochs):
            
            # calculate the gradient descent
            grad, mse = self.gradientDescent(x_train, y_train)

            # calculate the new weights
            w_new = self.__weights - lr * grad

            self.addHistory(i+1, self.evaluate(x_test, y_test), mse, np.copy(self.__weights))

            # check stopping conditions
            if np.sum(np.abs(w_new - self.__weights)) < delta:
                print("No improvements, stopping...")
                break

            self.__weights = w_new

        return self.history

    def stochasticGradientDescent(self, x_train, y_train, x_test, y_test, lr=0.001, epochs=100, no_improve_epochs=10, history_interval=10):
        """Executes stochastic gradient descent

        Args:
            x_train (np.Array): a numpy array of dimension (n x input_size) n being the number of instances and input_size is the number of independent variables
            y_train (np.Array): a numpy array of dimension (n x 1) n being the number of instances, this contains the target training labels or values
            x_test (np.Array): same as x_train, but has the test data
            y_test (np.Array): same as y_train, but has the test data
            lr (float, optional): the learning rate. Defaults to 0.001.
            epochs (int, optional): the number of maximum epochs to execute. Defaults to 100.
            no_improve_epochs (int, optional): the number of epochs to run without improvements to the validation loss. Defaults to 10.
            history_interval (int, optional): the interval in which the history entries are collected. Defaults to 20.

        Returns:
            history: the collected history list
        """

        # shuffle train dataset
        train = shuffleDataset(concatDataset(x_train, y_train))
        (x_train, y_train) = (train[:, :-1], train[:, -1:])

        self.makeHistory()

        prev_err = None
        prev_epoch = None
        best_weights = None

        exit_train = False
        sample_count = len(train)

        i = 0
        j = 0
        for i in range(epochs):

            for j in range(sample_count):
                # get the single instance for training
                jx_train = [x_train[j]]
                jy_train = [y_train[j]]

                # calculate the gradient descent for single instance
                grad, mse = self.gradientDescent(jx_train, jy_train)

                # calculate new weights
                w_new = self.__weights - lr * grad

                if j % min(history_interval, sample_count) == 0:
                    err = self.evaluate(x_test, y_test)
                    self.addHistory(i+1, err, mse, np.copy(self.__weights), j+1, sample_count=sample_count)

                self.__weights = w_new

            if prev_err is None:
                prev_err = self.evaluate(x_test, y_test)
                prev_epoch = i
                best_weights = np.copy(self.__weights)
                continue

            err = self.evaluate(x_test, y_test)
            if prev_err > err:
                prev_err = err
                prev_epoch = i
                best_weights = np.copy(self.__weights)

            if (i - prev_epoch) > no_improve_epochs:
                print("No improvements after {} epochs, stopping...".format(no_improve_epochs))
                self._updateWeights(list(best_weights))
                break

            if exit_train:
                break

        return self.history

    def miniBatchGradientDescent(self, x_train, y_train, x_test, y_test, batchsize=64, lr=0.001, epochs=100, no_improve_epochs=10):
        """Executes mini-batch gradient descent

        Args:
            x_train (np.Array): a numpy array of dimension (n x input_size) n being the number of instances and input_size is the number of independent variables
            y_train (np.Array): a numpy array of dimension (n x 1) n being the number of instances, this contains the target training labels or values
            x_test (np.Array): same as x_train, but has the test data
            y_test (np.Array): same as y_train, but has the test data
            batchsize (int, optional): the number of training samples there needs to be in each batch. Defaults to 64.
            lr (float, optional): the learning rate. Defaults to 0.001.
            epochs (int, optional): the number of maximum epochs to execute. Defaults to 100.
            no_improve_epochs (int, optional): the number of epochs to run without improvements to the validation loss. Defaults to 10.

        Returns:
            history: the collected history list
        """

        # shuffle train dataset
        train = shuffleDataset(concatDataset(x_train, y_train))
        (x_train, y_train) = (train[:, :-1], train[:, -1:])

        self.makeHistory()

        prev_err = None
        prev_epoch = None
        best_weights = None

        i = 0
        j = 0

        early_stop = False
        batch_count = math.ceil(len(x_train) / batchsize)

        for i in range(epochs):

            for j in range(batch_count):

                # Get the batch
                x_batch = x_train[j*batchsize:(j+1)*batchsize]
                y_batch = y_train[j*batchsize:(j+1)*batchsize]
                curr_batch_size = len(x_batch)
                if curr_batch_size < batchsize:
                    rem = batchsize - curr_batch_size
                    x_batch = x_train[(j*batchsize)-rem:]
                    y_batch = y_train[(j*batchsize)-rem:]

                grad, mse = self.gradientDescent(x_batch, y_batch)

                # calculate new weights
                w_new = self.__weights - lr * grad

                self.addHistory(i+1, self.evaluate(x_test, y_test), mse, np.copy(self.__weights), j+1, sample_count=batch_count)

                self.__weights = w_new

            if prev_err is None:
                prev_err = self.evaluate(x_test, y_test)
                prev_epoch = i
                best_weights = np.copy(self.__weights)
                continue

            err = self.evaluate(x_test, y_test)
            if prev_err > err:
                prev_err = err
                prev_epoch = i
                best_weights = np.copy(self.__weights)

            if (i - prev_epoch) > no_improve_epochs:
                print("No improvements after {} epochs, stopping...".format(no_improve_epochs))
                self._updateWeights(list(best_weights))
                break

            # self.addHistory(i+1, self.evaluate(x_test, y_test), self.evaluate(x_train, y_train), np.copy(self.__weights))

            if early_stop:
                break

        if not early_stop:
            err = self.evaluate(x_test, y_test)
            mse = self.evaluate(x_train, y_train)
            self.addHistory(i+1, err, mse, np.copy(self.__weights), sample_count=batch_count, mini=batch_count)

        return self.history

    def __str__(self):
        return "RegressionModel -> input_size: {} | degree: {} | weights: {}".format(self.__input_size, self.__degree, self.__weights.T)

def loadIrisDataset():
    """Reads the iris.csv file and outputs a numpy array

    Returns:
        np.array: Iris Dataset
    """

    df = pd.read_csv("./iris.csv")
    
    df['class'] = df['class'].astype('category')

    mapping = df['class'].cat.categories

    cat_columns = df.select_dtypes(['category']).columns
    df[cat_columns] = df[cat_columns].apply(lambda x: x.cat.codes)

    X = df.drop(['class'], 1)
    Y = df['class']


    retMap = {}
    for lbl in enumerate(mapping):
        retMap[lbl[1]] = lbl[0]

    return (
        np.reshape(X.to_numpy(), (len(X), 4)),
        np.reshape(Y.to_numpy(), (len(Y), 1)),
        retMap
    )

def expandInputX(X, input_size=1, degree=1):
    """expand the input variable to the powers of the input example: [[1], [2]] can be
    expanded to a quadratic form with degree 2 -> [[1, 1, 1], [2, 4, 1]] the additional 1
    is for the constant term. This is helpful for the vectorization of the computation with
    the help of numpy

    Args:
        X (np.Array): The input as a matrix of shape (num_instances, input_size)
        input_size (int, optional): The number of dimensions of the vector. Defaults to 1.
        degree (int, optional): The degree of the polynomial. Defaults to 1.

    Raises:
        Exception: if the input is not of shape (num_instances, input_size) an exception is triggered

    Returns:
        np.Array: The expanded variables to it's powers and the constant term
    """

    x = np.zeros(shape=(len(X), input_size * degree + 1))
    X = np.array(X)
    if X.shape[1] != input_size:
        raise Exception("input shape should be of (n,{})".format(input_size))
    x[:,-1:] = np.ones(shape=(x.shape[0], 1))

    for i in range(input_size):
        si = degree * i
        ei = degree * i + degree
        y = np.zeros(shape=(x.shape[0], degree))
        y[:,:] = np.reshape(X[:,i], (x.shape[0], 1))
        x[:,si:ei] = np.power(y, range(1, degree+1))
    
    return x

def generatePoints(weights=None, input_size=1, degree=1, num_points=1000, noise=0.5, max=1000):
    """Generate random points in the form of the given degree

    Args:
        weights (list, optional): the coeffients and the constant term of the polynomial, if None randomly assigned
        input_size (int, optional): The variable count of the polynomial. Defaults to 1.
        degree (int, optional): The degree of the polynomial. Defaults to 1.
        num_points (int, optional): The number of points to generate. Defaults to 1000.
        noise (float, optional): The amount of deviation from the polynomial, essentially noise. Defaults to 0.5.
        max (int, optional): The maximum value that the input can range [0,max). Defaults to 1000.

    Returns:
        (np.Array, np.Array): The randomly generated points with it's respective input value
    """

    if weights is None:
        weights = np.random.rand(input_size * degree + 1) * np.random.randint(1, 20)

    w = np.array(weights)
    X = np.random.rand(num_points, input_size) * max
    x = expandInputX(X, input_size=input_size, degree=degree)

    d = (np.random.rand(num_points, 1) * 2 * noise) - noise

    r = np.reshape(np.matmul(x, w), (num_points, 1)) + d
    r = np.clip(r, 0, None)

    return (X, r)

def concatDataset(x, y):
    """Combine the input and target values of the dataset

    Args:
        x (np.Array): The input data
        y (np.Array): The target variable

    Returns:
        np.Array: Concatenated dataset
    """
    return np.append(x, y, axis=1)

def shuffleDataset(X, seed=None):
    """Shuffle the dataset randomly

    Args:
        X (np.Array): The combined input and target values of the dataset
        seed (int, optional): The seed value for the generator, will be random if seed=None. Defaults to None.

    Returns:
        np.Array: The shuffled dataset
    """
    if not seed is None:
        r = np.random.RandomState(seed)
        r.shuffle(X)
    else:
        np.random.shuffle(X)
    return X

def prepareDataset(x, y, y_size=1, train=0.8, seed=None):
    """Prepare a dataset into (x_train, y_train, x_test, y_test)

    Args:
        x (np.Array): The input feature matrix (num_instances x num_inputs)
        y (np.Array): The target matrix (num_instances x target_size) target_size is usually 1
        y_size (int, optional): The size of the target vector for a single instance. Defaults to 1.
        train (float, optional): The percentage of data which should go into the training set. Defaults to 0.8.
        seed (int, optional): The seed value. Defaults to None.

    Returns:
        (x_train, y_train, x_test, y_test): Prepared Dataset
    """
    (train, test) = splitDataset(shuffleDataset(concatDataset(x, y), seed=seed), train=train)
    (x_train, y_train) = (train[:, :-y_size], train[:, -y_size:])
    (x_test, y_test) = (test[:, :-y_size], test[:, -y_size:])
    return (x_train, y_train, x_test, y_test)

def splitDataset(X, train=0.8):
    """Split the dataset into train and test datasets

    Args:
        X (np.Array): The combined input and target values of the dataset
        train (float, optional): The percentage of data to be in training dataset 0 <= train <= 1. Defaults to 0.8

    Returns:
        (np.Array, np.Array): The splitted train and test datasets
    """
    index = int(len(X) * train)
    train = X[:index, :]
    test = X[index:, :]
    return (train, test)

def calculateMSE(W, x, y):
    """Calculate the MSE for plotting the contour map

    Args:
        W (np.Array): The weights
        x (np.Array): Input instances
        y (np.Array): Target instances

    Returns:
        float: The MSE for the given values
    """
    pred = x.dot(W)
    err = ((y - pred) ** 2) / 2
    mse = np.sum(err) / len(x)
    return mse

def drawLegend(ax):
    handles, labels = ax.get_legend_handles_labels()
    ax.legend(handles, labels)

def drawScatterPlot(ax, x, y, color='blue', label=None):
    ax.scatter(x, y, color=color, label=label)

def drawLinePlot(ax, x, y, color='blue', label=None):
    ax.plot(x, y, color=color, label=label)

def drawContourPlot(ax, x, y, z, title="", xlabel="", ylabel="", alpha=0.7, levels=None):
    cs = ax.contourf(x, y, z, alpha=alpha, levels=levels)
    plt.colorbar(cs)
    # ax.clabel(cs, inline=1, fontsize=10)
    ax.set_title(title)
    ax.set_xlabel(xlabel)
    ax.set_ylabel(ylabel)

def drawHistoryPath(ax, history, w0index=0, w1index=1):
    """Draw the path on the contour plot
    """

    weight_coords = [np.array([w["weights"][w0index, 0], w["weights"][w1index, 0]]) for w in history]
    sum_d = 0.0
    weight_count = len(weight_coords)
    for i in range(weight_count-1):
        sum_d += (np.sum((weight_coords[i] - weight_coords[i+1]) ** 2)) ** (1/2)
    avg_d = (sum_d / (weight_count - 1))

    i = 0
    j = 0
    while i < (weight_count - 1):

        j = i + 1
        # j_d = None
        # while j < weight_count and (j_d is None or j_d < avg_d):
        #     j_d = (np.sum((weight_coords[i] - weight_coords[j]) ** 2)) ** (1/2)
        #     if  j_d < avg_d:
        #         j += 1

        if not (j < weight_count):
            j = weight_count - 1

        p0 = weight_coords[i]
        p1 = weight_coords[j]
        ax.annotate('', xy=p1, xytext=p0, arrowprops={'arrowstyle': '->', 'color': 'r'}, va='center', ha='center')

        i = j

def drawHistoryLoss(ax, history):
    val_loss = []
    train_loss = []
    epoch = []

    for h in history:
        val_loss.append(h["val_loss"])
        train_loss.append(h["train_loss"])
        epoch.append(h["epoch"])

    ax.plot(epoch, val_loss, color='red', label='Validation Loss')
    ax.plot(epoch, train_loss, color='blue', label='Training Loss')

    ax.set_title("MSE vs Epochs")
    ax.set_xlabel("Epochs")
    ax.set_ylabel("MSE")

def prepareContourData(weights, x, y, input_size, degree, weight_range=20, data_points=100, w0index=0, w1index=1):
    """Prepare Data Required for the Contour Plot

    Args:
        weights (np.Array): The weights of the model
        x (np.Array): input array to calculate MSE
        y (np.Array): target values to calculate MSE
        input_size (int): The input size
        weight_range (float): The range to calculate weights for
        degree (int): degree of the polynomial
        data_points (int): the number of data points to plot
        w0index (int, optional): The plotting index 0. Defaults to 0.
        w1index (int, optional): The plotting index 1. Defaults to 1.

    Returns:
        (np.Array, np.Array, np.Array): (x axis, y axis, z mesh)
    """

    w0 = np.linspace(weights[w0index] - weight_range, weights[w0index] + weight_range, data_points)
    w1 = np.linspace(weights[w1index] - weight_range, weights[w1index] + weight_range, data_points)
    z = np.zeros(shape=(w0.size, w1.size))
    x = expandInputX(x, input_size=input_size, degree=degree)

    for i, vi in enumerate(w0):
        for j, vj in enumerate(w1):
            w = np.copy(weights)
            w[w0index] = vi
            w[w1index] = vj
            z[i, j] = calculateMSE(w, x, y)

    return (w0.T[0], w1.T[0], z)

def fitModelWithGD(dataset, model, gd_type="batch", delta=1e-6, epochs=1000, lr=0.001, batch_size=64, no_improve_epochs=10):
    """Fit the given model to the given dataset using a type of gradient descent

    Args:
        dataset ((x_train, y_train, x_test, y_test)): The dataset created using `prepareDataset`
        model (RegressionModel): The regression model
        gd_type (str, optional): The type of gradient descent. Can be "batch", "mini-batch" or "stochastic". Defaults to "batch".
        delta (float): The minimum change that is needed in the weights to continue the learning (used only in "batch" gd)
        epochs (int): The number of maximum epochs to run
        lr (float): The learning rate
        batch_size (int): The number of instances in a batch (only used when gd_type = "mini-batch")
        no_imporve_epochs (int): The number of epochs to continue without validation error decreasing

    Raises:
        Exception: Error occurs if gd_type is not valid

    Returns:
        (history, model): returns the history of the weight updates and the model that has learnt
    """

    (x_train, y_train, x_test, y_test) = dataset
    history = None
    if gd_type == "batch":
        history = model.batchGradientDescent(x_train, y_train, x_test, y_test, lr, epochs, delta=delta)
    elif gd_type == "mini-batch":
        history = model.miniBatchGradientDescent(x_train, y_train, x_test, y_test, lr=lr, epochs=epochs, no_improve_epochs=no_improve_epochs, batchsize=batch_size)
    elif gd_type == "stochastic":
        history = model.stochasticGradientDescent(x_train, y_train, x_test, y_test, lr, epochs, no_improve_epochs=no_improve_epochs)
    else:
        raise Exception("Invalid Gradient Descent Type")
    return (history, model)

def plotWeightContours(weights, history, x, y, input_size, degree, data_points=100):
    """Plot contours for every combination of the weights

    Args:
        weights (np.Array): The weights learnt by the model
        history (Any): History of the weight updates
        x (np.Array): sample inputs to calculate the SSE
        y (np.Array): sample targets to the x
        input_size (int): The input_size of the model
        degree (int): The degree of the model
        data_points (int, optional): The number of data points to be plot on an axis (final z matrix (data_points x data_points)). Defaults to 100.
    """

    weight_count = input_size * degree + 1
    w0index = 0
    w1index = 1
    
    sw = history[0]["weights"]
    ew = history[-1]["weights"]

    for w0index in range(0, weight_count):
        for w1index in range(w0index+1, weight_count):
            # calculate the plotting area for the contour
            wra = np.abs(sw - ew)
            wr = wra[w0index, 0] if wra[w0index, 0] > wra[w1index, 0] else wra[w1index, 0]

            (cx, cy, cz) = prepareContourData(weights, x, y, w0index=w0index, w1index=w1index, input_size=input_size, degree=degree, weight_range=wr, data_points=data_points)
            fig = plt.figure(figsize=plt.figaspect(0.5))
            ax = fig.add_subplot(1, 1, 1)
            drawContourPlot(ax, cx, cy, cz, title="(weight - {}, weight - {}) VS MSE".format(w0index+1, w1index+1), xlabel="weight - {}".format(w0index+1), ylabel="weight - {}".format(w1index+1), levels=100)
            drawHistoryPath(ax, history, w0index=w0index, w1index=w1index)
            plt.show()

def fitModel(dataset, gd_type="batch", input_size=1, degree=1, weights=None, delta=1e-6, epochs=1000, lr=0.001, batch_size=64, no_improve_epochs=10, plot_contours=True):
    """Fit the given model to the given dataset using a type of gradient descent

    Args:
        dataset ((x_train, y_train, x_test, y_test)): The dataset created using `prepareDataset`
        gd_type (str, optional): The type of gradient descent. Can be "batch", "mini-batch" or "stochastic". Defaults to "batch".
        input_size (int, optional): The input_size of the model. Defaults to 1.
        degree (int, optional): The degree of the model. Defaults to 1.
        weights (list, optional): define the weights of the model, for example if for linear equations ax+b = y, define a and b. Defaults to None.
        delta (float, optional): The minimum change that is needed in the weights to continue the learning. Defaults to 1e-6.
        epochs (int, optional): The number of maximum epochs to run. Defaults to 1000.
        lr (float, optional): The learning rate. Defaults to 0.001.
        batch_size (int, optional): The number of instances in a batch (only used when gd_type = "mini-batch"). Defaults to 64.
        no_imporve_epochs (int, optional): The number of epochs to continue without validation error decreasing. Defaults to 10.

    Returns:
        model: returns the model that has learnt
    """
    
    (x_train, y_train, _, _) = dataset

    model = RegressionModel(input_size, degree=degree, weights=weights)

    x_plot = None
    y_post_plot = None
    y_pre_plot = None
    if input_size == 1:
        x_plot = np.linspace(0, max(x_train), num=100)
        x_plot = np.reshape(x_plot, (len(x_plot), 1))
        y_pre_plot = model.predict(x_plot)

    (history, model) = fitModelWithGD(dataset, model, gd_type=gd_type, delta=delta, epochs=epochs, lr=lr, batch_size=batch_size, no_improve_epochs=no_improve_epochs)

    if input_size == 1:
        y_post_plot = model.predict(x_plot)

    fig = plt.figure(figsize=plt.figaspect(0.5))

    ax = None
    if input_size > 1:
        ax = fig.add_subplot(1, 1, 1)
    else:
        ax = fig.add_subplot(2, 1, 1)
    drawHistoryLoss(ax, history)
    drawLegend(ax)

    if input_size == 1:
        ax = fig.add_subplot(2, 1, 2)
        ax.set_title("Prediction Lines")
        drawScatterPlot(ax, x_train, y_train, color='blue')
        drawLinePlot(ax, x_plot, y_pre_plot, color='orange', label='pre train predictions')
        drawLinePlot(ax, x_plot, y_post_plot, color='red', label='post train predictions')
        drawLegend(ax)

    plt.show()

    if plot_contours:
        plotWeightContours(model.getWeights(), history, x=x_train, y=y_train, input_size=input_size, degree=degree, data_points=200)

    return model

def fitMultipleModels(dataset, gd_type="batch", input_size=1, degree=1, weights=None, delta=1e-6, epochs=1000, lr=0.001, batch_size=64, no_improve_epochs=10, plot_scatter=True, plot_contours=True):
    """Fit Multiple Models and show the learning rates of each model
    """

    models = []

    if isinstance(lr, list):
        for l in lr:
            models.append({
                "lr": l,
                "model": RegressionModel(input_size, degree=degree, weights=weights)
            })
    else:
        models.append({
            "lr": lr,
            "model": RegressionModel(input_size, degree=degree, weights=weights)
        })

    for i, model in enumerate(models):
        print("------------------ Training Model[{}] - lr={} ------------------".format(i, model["lr"]))
        (history, model_) = fitModelWithGD(dataset, model["model"], gd_type=gd_type, delta=delta, epochs=epochs, lr=model["lr"], batch_size=batch_size, no_improve_epochs=no_improve_epochs)
        model["model"] = model_
        model["history"] = history

    for model in models:
        # val_loss = []
        train_loss = []
        epoch = []
        for h in model["history"]:
            # val_loss.append(h["val_loss"])
            train_loss.append(h["train_loss"])
            epoch.append(h["epoch"])
        # plt.plot(epoch, val_loss, label='Val Loss lr={}'.format(model["lr"]))
        plt.plot(epoch, train_loss, label='Train Loss lr={}'.format(model["lr"]))
        plt.title("MSE vs Epochs (With Learning Rate)")
        plt.xlabel("Epochs")
        plt.ylabel("MSE")
        plt.legend()

    plt.show()

    return [model["model"] for model in models]

def fitIrisModel(dataset, gd_type="batch", degree=1, weights=None, delta=1e-6, epochs=1000, lr=0.001, batch_size=64, no_improve_epochs=10, plot_contours=True):
    """Fit a model to the iris dataset

    Args:
        dataset ((x_train, y_train, x_test, y_test)): The dataset created using `prepareDataset`
        gd_type (str, optional): The type of gradient descent. Can be "batch", "mini-batch" or "stochastic". Defaults to "batch".
        degree (int, optional): The degree of the model. Defaults to 1.
        weights (list, optional): define the weights of the model, for example if for linear equations ax+b = y, define a and b. Defaults to None.
        delta (float, optional): The minimum change that is needed in the weights to continue the learning. Defaults to 1e-6.
        epochs (int, optional): The number of maximum epochs to run. Defaults to 1000.
        lr (float, optional): The learning rate. Defaults to 0.001.
        batch_size (int, optional): The number of instances in a batch (only used when gd_type = "mini-batch"). Defaults to 64.
        no_imporve_epochs (int, optional): The number of epochs to continue without validation error decreasing. Defaults to 10.

    Returns:
        model: returns the model that has learnt
    """

    (x_train, y_train, _, _) = dataset

    input_size = 4

    model = RegressionModel(input_size=input_size, degree=degree, weights=weights)

    (history, model) = fitModelWithGD(dataset, model, gd_type=gd_type, delta=delta, epochs=epochs, lr=lr, batch_size=batch_size, no_improve_epochs=no_improve_epochs)

    fig = plt.figure(figsize=plt.figaspect(0.5))

    ax = fig.add_subplot(1, 1, 1)
    drawHistoryLoss(ax, history)
    drawLegend(ax)

    plt.show()

    if plot_contours:
        plotWeightContours(model.getWeights(), history, x=x_train, y=y_train, input_size=input_size, degree=degree, data_points=200)
    
    return model

if __name__ == "__main__":

    # print("Gradient Descent")
    # print("[1] Random - Linear Dataset")
    # print("[2] Random - Quadratic Dataset")
    # print("[3] Iris Dataset")
    # dt = int(input("Select [1]: "))
    # if dt not in [1, 2, 3]:
    #     dt = 1

    # print("Select Type of Grandient Descent")
    # print("[1] Batch Gradient Descent")
    # print("[2] Stochastic Gradient Descent")
    # print("[3] Mini-Batch Gradient Descent")
    # bt = int(input("Select [1]: "))

    # gd_type = "batch"
    # if bt == 1:
    #     gd_type = "batch"
    # elif bt == 2:
    #     gd_type = "stochastic"
    # elif bt == 3:
    #     gd_type = "mini-batch"

    # # Change the parameters of the datasets by changing the values

    # if dt == 1:
    #     (x, y) = generatePoints(input_size=1, degree=1, num_points=1000, noise=1, max=5)
    #     dataset = prepareDataset(x, y)
    #     model = fitModel(dataset, gd_type=gd_type, input_size=1, degree=1, delta=1e-6, epochs=4000, lr=0.01, batch_size=64, no_improve_epochs=10, plot_contours=True)
    # if dt == 2:
    #     (x, y) = generatePoints(input_size=1, degree=2, num_points=1000, noise=1, max=5)
    #     dataset = prepareDataset(x, y)
    #     model = fitModel(dataset, gd_type=gd_type, input_size=1, degree=2, delta=1e-6, epochs=4000, lr=0.01, batch_size=64, no_improve_epochs=10, plot_contours=True)
    # elif dt == 3:
    #     (x, y, refmap) = loadIrisDataset()
    #     dataset = prepareDataset(x, y)
    #     model = fitIrisModel(dataset, gd_type=gd_type, degree=1, delta=1e-6, epochs=1000, lr=0.0001, batch_size=32, no_improve_epochs=10, plot_contours=True)
    
    # (x, y) = generatePoints(weights=[4, 2], input_size=1, degree=1, num_points=100, noise=2.5, max=5)
    # dataset = prepareDataset(x, y)
    # model = fitModel(dataset, weights=[20, 1], gd_type="mini-batch", input_size=1, degree=1, delta=0.001, epochs=100, lr=0.01, batch_size=16, no_improve_epochs=10, plot_contours=True)

    (x, y) = generatePoints(weights=[4, 2], input_size=1, degree=1, num_points=500, noise=10, max=5)
    dataset = prepareDataset(x, y)
    model = fitModel(dataset, weights=[10, 1], gd_type="stochastic", input_size=1, degree=1, delta=0.001, epochs=1000, lr=0.005, batch_size=16, no_improve_epochs=1, plot_contours=True)

    # (x, y) = generatePoints(weights=[5, 1], input_size=1, degree=1, num_points=1000, noise=0.5, max=2)
    # dataset = prepareDataset(x, y)
    # model = fitMultipleModels(dataset, weights=[3, 3], gd_type="batch", input_size=1, degree=1, delta=1e-4, epochs=5000, lr=[0.01], batch_size=64, no_improve_epochs=10, plot_contours=True)