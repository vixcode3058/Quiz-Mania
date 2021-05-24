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

namespace Quiz_Mania
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Questions> questions;

        public object MyStorage { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // questions = new List<Questions>();

            //            Questions q = new Questions { id = 1, text = " qestion" };
            //          q.answers.Add(new Answer { answer = " option 1", status = false });
            //        q.answers.Add(new Answer { answer = " option 2", status = false });
            //      q.answers.Add(new Answer { answer = " option 3", status = false });
            //    q.answers.Add(new Answer { answer = " option 4", status = true });

            //  SP_question.DataContext = q;
            //questions.Add(q);

            // MyStorage.WriteXML < List<Questions>("Questions.xml", questions);
            // MyStorag.WriteXML<List<Questions>>( questions, "Questions.xml");

           questions= MyStorag.ReadXml<List<Questions>>("Questions.xml");
            SP_question.DataContext = questions[2];
        } 

        private void LBx_answers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ans = (sender as ListBox).SelectedItem as Answer;
            if (ans.status)
            {
                
                MessageBox.Show("It was the correct");
            }
            else
            {
                MessageBox.Show(String.Format("It was the wrong \n the right ans is :",GetRightAnswer()));

            }
        }

        private object GetRightAnswer()
        {
            foreach (var item in LBx_answers.Items)
            {
                if((item as Answer).status)
                {
                    return (item as Answer).answer;
                }
                
            }
            return "We did bad job";
        }

        private void BTn_Help_Click(object sender, RoutedEventArgs e)
        {
            Help win = new Help();
            win.Owner = this;
            win.Show();
        }
    }
}
