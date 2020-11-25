## How to Run

requires
- python 3
- numpy

python main.py [options]

### OPTIONS

-md [string]   : model name "perceptron", "adaline", "madaline" (default = "perceptron")
-ds [string]   : dataset name "and", "or", "nand", "nor", "xor" (default = "and")
-lr [float]    : the learning rate (default = 0.1)
-it [integer]  : the number of iterations the whole dataset will be trained (default = 5)
-nfl [integer] : the number of nodes in the hidden layer of madaline (default = 5)

### EXAMPLE

```bash
python main.py -md adaline -lr 0.5 -ds or -it 200
```