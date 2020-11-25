import numpy as np
import sys

ANDset = (
  ([1, 1], 1),
  ([1, 0], 0),
  ([0, 1], 0),
  ([0, 0], 0)
)

NANDset = (
  ([1, 1], 0),
  ([1, 0], 1),
  ([0, 1], 1),
  ([0, 0], 1)
)

ORset = (
  ([1, 1], 1),
  ([1, 0], 1),
  ([0, 1], 1),
  ([0, 0], 0)
)

NORset = (
  ([1, 1], 0),
  ([1, 0], 0),
  ([0, 1], 0),
  ([0, 0], 1)
)

XORset = (
  ([1, 1], 0),
  ([1, 0], 1),
  ([0, 1], 1),
  ([0, 0], 0)
)

class Perceptron():

  def __init__(self, n_inputs, learning_rate):
    self.bias = -1
    self.learning_rate = learning_rate
    self.weights = np.random.rand(n_inputs+1)

  def train(self, X, y):
    X = np.array(X)
    yp = self.predict(X)
    diff = y - yp
    if diff == 0:
      return
    if diff > 0:
      nw = self.weights + self.learning_rate * np.append([self.bias], X)
    else:
      nw = self.weights - self.learning_rate * np.append([self.bias], X)
    self.weights = nw

  def predict(self, X):
    X = np.append([self.bias], list(X))
    return 1 if np.matmul(self.weights, X.T) > 0 else 0

  def __str__(self):
    return "Perceptron: inputs = {} | learning_rate = {}".format(len(self.weights)-1, self.learning_rate)

class Adaline():

  def __init__(self, n_inputs, learning_rate):
    self.bias = -1
    self.learning_rate = learning_rate
    self.weights = np.random.rand(n_inputs+1)

  def train(self, X, y):
    X = np.array(X)
    yp = self.predict(X)
    self.update_weights(yp, y, X)

  def update_weights(self, yp, y, X):
    diff = y - yp
    self.weights = self.weights + self.learning_rate * diff * np.append([self.bias], X)

  def predict(self, X):
    X = np.append([self.bias], list(X))
    yp = np.matmul(self.weights, X.T)
    return 1 if yp > 0 else 0

  def __str__(self):
    return "Adaline: inputs = {} | learning_rate = {}".format(len(self.weights)-1, self.learning_rate)

class MAdaline():
  def __init__(self, n_inputs, learning_rate, n_first_layer_nodes):
    self.first_layer = [Adaline(n_inputs, learning_rate) for _ in range(n_first_layer_nodes)]
    self.final_layer = Adaline(n_first_layer_nodes, learning_rate)

  def train(self, X, y):
    X = np.array(X)
    yp = self.predict(X)

    first_layer_X = [p.predict(X) for p in self.first_layer]

    self.final_layer.update_weights(yp, y, first_layer_X)
    [p.update_weights(yp, y, X) for p in self.first_layer]


  def predict(self, X):
    first_layer_x = [p.predict(X) for p in self.first_layer]
    return self.final_layer.predict(first_layer_x)

  def __str__(self):
    s = "final layer: {}\n".format(str(self.final_layer))
    s += "first layer: {} x {}".format(len(self.first_layer), str(self.first_layer[0]))
    return s



def evaluate_with_info(dset, fn_predict):
  correct = 0
  for d in dset:
    yp = fn_predict(d[0])
    if yp == d[1]:
      correct += 1
  acc = (correct / len(dset)) * 100.0
  print("Accuracy: {}".format(acc))

def train_with_info(dset, iters, fn_train, fn_predict, pr=1):
  for i in range(0, iters):
    for d in dset:
      fn_train(d[0], d[1])
    if i % pr == 0:
      print("Iteration: {} / {}".format(i+1, iters))
      evaluate_with_info(dset, fn_predict)
  print("")

def predict_for_dataset(dset, fn_predict):
  print("Input  | Real | Predicted")
  for d in dset:
    X = d[0]
    yp = fn_predict(X)
    y = d[1]
    print("{} | {}    | {}".format(X, y, yp))


def get_dataset(name):
  name = name.lower()
  if name == "and":
    return ANDset
  elif name == "or":
    return ORset
  elif name == "xor":
    return XORset
  elif name == "nand":
    return NANDset
  elif name == "nor":
    return NORset
  raise Exception("Incorrect Dataset Name")

def model_factory(name, **args):
  name = name.lower()
  if name == "perceptron":
    return Perceptron(args['n_inputs'], args['learning_rate'])
  elif name == "adaline":
    return Adaline(args['n_inputs'], args['learning_rate'])
  elif name == "madaline":
    return MAdaline(args['n_inputs'], args['learning_rate'], args['n_first_layer_nodes'])
  raise Exception("Incorrect Model Name")

def parse_cmd_args():
  d = {
  "dataset": "and",
  "model": "perceptron",
  "n_inputs": 2,
  "learning_rate": 0.1,
  "n_first_layer_nodes": 5,
  "iterations": 5,
  "help": False
  }
  args = sys.argv[1:]
  for (i, arg) in enumerate(args):
    if arg == "-help" or arg == "-h":
      d['help'] = True
      return d
    if i-1 < 0:
      continue
    prevarg = args[i-1]
    if prevarg == '-ds':
      d['dataset'] = arg
    elif prevarg == '-md':
      d['model'] = arg
    elif prevarg == '-lr':
      d['learning_rate'] = float(arg)
    elif prevarg == '-nfl':
      d['n_first_layer_nodes'] = int(arg)
    elif prevarg == '-it':
      d['iterations'] = int(arg)
  return d

def display_help():
  print("""OPTIONS
-md [string]   : model name "perceptron", "adaline", "madaline" (default = "perceptron")
-ds [string]   : dataset name "and", "or", "nand", "nor", "xor" (default = "and")
-lr [float]    : the learning rate (default = 0.1)
-it [integer]  : the number of iterations the whole dataset will be trained (default = 5)
-nfl [integer] : the number of nodes in the hidden layer of madaline (default = 5)

RUN
python main.py [OPTIONS]

EXAMPLE
python main.py -md adaline -lr 0.5 -ds or -it 200=""")

if __name__ == "__main__":
  args = parse_cmd_args()
  
  if args['help']:
    display_help()
    sys.exit(0)

  model = model_factory(args['model'], n_inputs=args['n_inputs'], learning_rate=args['learning_rate'], n_first_layer_nodes=args['n_first_layer_nodes'])
  dset = get_dataset(args['dataset'])

  print("------------- PRE - TRAIN --------------")
  predict_for_dataset(dset, model.predict)

  print("--------------- TRAINING ---------------")
  train_with_info(dset, args['iterations'], model.train, model.predict)
  # for _ in range(args['iterations']):
  #   for d in dset:
  #     model.train(d[0], d[1])

  print("------------- POST - TRAIN -------------")
  predict_for_dataset(dset, model.predict)




# print(model_factory("perceptron", n_inputs=2, learning_rate=0.2))

# n = MAdaline(n_inputs=2, learning_rate=0.2, n_first_layer_nodes=5)

# dset = ANDset

# train_with_info(dset, 5, n.train, n.predict)
