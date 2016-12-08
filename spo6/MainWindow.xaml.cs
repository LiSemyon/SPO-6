using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace spo6 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            String text = textBox.Text;

            text = text.ToLower();

            String[] text_expressions = text.Split(MyLanguage.limiter);

            List<string> identificators = new List<string>();
            List<string> operation_marks = new List<string>();
            List<string> constants = new List<string>();
            //пофиксить идентификаторы
            for (int i = 0; i < text_expressions.Length; i++) {

                for (int op = 0; op < MyLanguage.operation_marks.Length; op++) { //операторы
                    String[] split_operators = text_expressions[i].Split(' ');
                    for (int s = 0; s < split_operators.Length; s++) {
                        if (split_operators[s].Equals(MyLanguage.operation_marks[op])) {
                            operation_marks.Add(MyLanguage.operation_marks[op]);
                        }
                    }

                }

                for (int om = 0; om < operation_marks.Count; om++) {
                    text_expressions[i] = text_expressions[i].Replace(operation_marks[om], "");
                }

                for (int j = 0; j < text_expressions[i].Length; j++) {
                        for (int t = 0; t < MyLanguage.identificators.Length; t++) { //идентификаторы
                            String _element = text_expressions[i][j].ToString();
                            if (_element.Equals(MyLanguage.identificators[t])) {
                                identificators.Add(MyLanguage.identificators[t]);
                            }
                        }
                        for (int c = 0; c < MyLanguage.constants.Length; c++) { //константы
                            if (text_expressions[i][j].ToString().Equals(MyLanguage.constants[c])) {
                                constants.Add(MyLanguage.constants[c]);
                            }
                        }
                    }
            }

            textBox2.Text = "Переменные: ";
            for (int i = 0; i < identificators.Count; i++) {
                textBox2.Text += identificators[i] + " ";
            }


            textBox2.Text += Environment.NewLine + "Константы: ";
            for (int i = 0; i < constants.Count; i++) {
                textBox2.Text += constants[i] + " ";
            }

            textBox2.Text += Environment.NewLine + "Знаки операций: ";
            for (int i = 0; i < operation_marks.Count; i++) {
                textBox2.Text += operation_marks[i] + " ";
            }

            if (text.Contains(MyLanguage.string_prisvain)) {
                textBox2.Text += Environment.NewLine +  "Знак присваивания: " + MyLanguage.prisvain;
            }

            textBox2.Text += Environment.NewLine + Environment.NewLine;

            textBox2.Text += "Логическое выражение: идентификаторы, константы и оператор";

            String[] expressions = text.Split(';');
            textBox2.Text += Environment.NewLine + "Выражения: ";
            for (int i = 0; i < expressions.Length; i++) {
                if (expressions[i].Split('=').Length > 1) {
                    textBox2.Text += expressions[i].Split('=')[1];
                    textBox2.Text += Environment.NewLine;
                }

            }

            textBox2.Text += "Идентификаторы: ";
            for (int i = 0; i < identificators.Count; i++) {
                textBox2.Text += identificators[i] + " ";
            }
            textBox2.Text += Environment.NewLine;
            textBox2.Text += "Операторы: ";
            for (int i = 0; i < operation_marks.Count; i++) {
                textBox2.Text += operation_marks[i] + " ";
            }

        }
    }
}
