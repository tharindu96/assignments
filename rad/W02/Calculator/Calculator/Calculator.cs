using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private static bool decimal_added = false;

        private enum STATE {
            INSERT_CHARACTER,
            INSERT_BINARY_OP,
            INSERT_UNARY_OP
        };

        public enum OPERATION
        {
            NULL,
            ADD,
            SUB,
            DIV,
            MUL,
            NEG,
            EQUAL
        };

        private STATE state = STATE.INSERT_CHARACTER;
        private OPERATION active_op = OPERATION.NULL;

        private double total = 0;

        private LinkedList<string> history;
        private string currentBuffer = "0";

        private CalculatorWindow calcWindow;

        public Calculator(CalculatorWindow win)
        {
            calcWindow = win;
            win.onCurrentValueChange(currentBuffer);
            history = new LinkedList<string>();
        }

        public void insertOP(OPERATION op)
        {
            double res;
            Double.TryParse(currentBuffer, out res);

            if (op == OPERATION.NEG)
            {
                res = -res;
                total = res;
                calcWindow.onCurrentValueChange(total.ToString());
                return;
            }

            if (active_op == OPERATION.NULL)
            {
                total += res;
                calcWindow.onCurrentValueChange(total.ToString());
                active_op = op;
                state = STATE.INSERT_BINARY_OP;
                return;
            }

            switch (active_op)
            {
                case OPERATION.ADD:
                    total += res;
                    break;
                case OPERATION.SUB:
                    total -= res;
                    break;
                case OPERATION.DIV:
                    total /= res;
                    break;
                case OPERATION.MUL:
                    total *= res;
                    break;
            }

            active_op = op;

            calcWindow.onCurrentValueChange(total.ToString());
            state = STATE.INSERT_BINARY_OP;
        }

        public void insertDigit(char n)
        {
            if (state != STATE.INSERT_CHARACTER)
            {
                currentBuffer = "0";
                decimal_added = false;
            }
            if (n == '.')
            {
                if (decimal_added)
                {
                    return;
                }
                else
                {
                    currentBuffer += n;
                    decimal_added = true;
                }
            }
            else
            {
                if (currentBuffer == "0")
                    currentBuffer = n.ToString();
                else
                    currentBuffer += n;
            }
            calcWindow.onCurrentValueChange(currentBuffer);
            state = STATE.INSERT_CHARACTER;
        }

        public void clear()
        {
            state = STATE.INSERT_CHARACTER;
            active_op = OPERATION.NULL;
            decimal_added = false;
            currentBuffer = "0";
            total = 0;
            history.Clear();
            calcWindow.onCurrentValueChange(currentBuffer);
        }
    }
}
