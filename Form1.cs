namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var measureItems = new string[]
            {
            "кв.м",
            "га",
            "ар",
            "десятин",
            };

            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private MeasureType GetMeasureType(ComboBox comboBox)
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "кв.м":
                    measureType = MeasureType.mm;
                    break;
                case "га":
                    measureType = MeasureType.ga;
                    break;
                case "ар":
                    measureType = MeasureType.ar;
                    break;
                case "десятин":
                    measureType = MeasureType.des;
                    break;
                default:
                    measureType = MeasureType.mm;
                    break;
            }
            return measureType;
        }

        private void Calculate()
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstLength = new Square(firstValue, firstType);
                var secondLength = new Square(secondValue, secondType);

                Square sumLength;

                switch (cmbOperation.Text)
                {
                    case "+":
                        sumLength = firstLength + secondLength;
                        break;
                    case "-":
                        sumLength = firstLength - secondLength;
                        break;
                    case "*":
                        sumLength = firstLength * secondLength;
                        break;
                    default:
                        sumLength = new Square(0, MeasureType.mm);
                        break;
                }

                txtResult.Text = sumLength.To(resultType).Verbose();
            }
            catch (FormatException)
            {

            }
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}