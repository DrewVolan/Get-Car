using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetAppCar1
{
    public partial class Form1 : Form
    {
        public string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\avoleyko\Desktop\Учёба\ЛР 1\GetAppCar1\GetAppCar1\GetCarServer.mdf';Integrated Security=True;Connect Timeout=30";
        private SqlConnection sqlConnection;
        public List<Question> Questions;
        public List<Answer> Answers;
        public List<Car> Cars;
        public List<RulesSimple> SimpleRules;
        public List<RulesComplex> ComplexRules;
        public Question Question;
        public Answer FirstAnswer;
        public Answer SecondAnswer;
        public string Result = string.Empty;

        public Form1()
        {
            InitializeComponent();
            Questions = new List<Question>();
            Answers = new List<Answer>();
            Cars = new List<Car>();
            SimpleRules = new List<RulesSimple>();
            ComplexRules = new List<RulesComplex>();
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            if (button.Text == "Начать")
            {
                sqlConnection = new SqlConnection(ConnectionString);
                await sqlConnection.OpenAsync();
                SqlDataReader sdr = null;
                SqlCommand selectQuestions = new SqlCommand("SELECT * FROM [Вопросы]", sqlConnection);
                SqlCommand selectAnswers = new SqlCommand("SELECT * FROM [Варианты ответов]", sqlConnection);
                SqlCommand selectCars = new SqlCommand("SELECT * FROM [Товары]", sqlConnection);
                SqlCommand selectSimpleRules = new SqlCommand("SELECT * FROM [RulesSimple]", sqlConnection);
                SqlCommand selectComplexRules = new SqlCommand("SELECT * FROM [RulesComplex]", sqlConnection);
                try
                {
                    sdr = await selectQuestions.ExecuteReaderAsync();
                    while (await sdr.ReadAsync())
                    {
                        Questions.Add(new Question(int.Parse(sdr["Id"].ToString()), sdr["Вопрос"].ToString()));
                    }
                    sdr.Close();
                    sdr = await selectAnswers.ExecuteReaderAsync();
                    while (await sdr.ReadAsync())
                    {
                        Answers.Add(new Answer(int.Parse(sdr["Id"].ToString()), int.Parse(sdr["Id вопроса"].ToString()), int.Parse(sdr["Id следующего вопроса"].ToString()), sdr["Вариант ответа"].ToString(), sdr["Параметр"].ToString()));
                    }
                    sdr.Close();
                    sdr = await selectCars.ExecuteReaderAsync();
                    while (await sdr.ReadAsync())
                    {
                        Cars.Add(new Car(sdr["Марка"].ToString(), sdr["Модель"].ToString(), int.Parse(sdr["Цена"].ToString()), int.Parse(sdr["Год выпуска"].ToString()), sdr["Тип двигателя"].ToString(), sdr["Тип коробки"].ToString(), sdr["Привод"].ToString(), sdr["Тип кузова"].ToString()));
                    }
                    sdr.Close();
                    sdr = await selectSimpleRules.ExecuteReaderAsync();
                    while (await sdr.ReadAsync())
                    {
                        SimpleRules.Add(new RulesSimple(int.Parse(sdr["Id"].ToString()), sdr["Parameter"].ToString(), sdr["ParameterValue"].ToString(), sdr["Attribute"].ToString(), sdr["AttributeValue"].ToString(), sdr["ComparisonOperation"].ToString()));
                    }
                    sdr.Close();
                    sdr = await selectComplexRules.ExecuteReaderAsync();
                    while (await sdr.ReadAsync())
                    {
                        ComplexRules.Add(new RulesComplex(int.Parse(sdr["Id"].ToString()), sdr["Parameter1"].ToString(), sdr["ParameterValue1"].ToString(),sdr["Operation"].ToString(), sdr["Parameter2"].ToString(), sdr["ParameterValue2"].ToString(), sdr["Attribute"].ToString(), sdr["AttributeValue"].ToString(), sdr["ComparisonOperation"].ToString()));
                    }
                    sdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sdr != null) sdr.Close();
                    sqlConnection.Close();
                }
                button.Text = "Следующий";
                Question = Questions[0];
                FirstAnswer = Answers.First(x => x.IdQuestion == Question.Id);
                SecondAnswer = Answers.First(x => x.IdQuestion == Question.Id && x.Id != FirstAnswer.Id);
                questionLabel.Text = Question.QuestionText;
                radioButton1.Visible = true;
                radioButton1.Text = FirstAnswer.AnswerText;
                radioButton2.Visible = true;
                radioButton2.Text = SecondAnswer.AnswerText;
            }
            else if ((radioButton1.Checked && FirstAnswer.IdNextQuestion != 0) || (radioButton2.Checked && SecondAnswer.IdNextQuestion != 0))
            {
                if (radioButton1.Checked) 
                {
                    Result += FirstAnswer.Parameter + ";";
                    Question = Questions.First(x => x.Id == FirstAnswer.IdNextQuestion);
                }
                else
                {
                    Result += SecondAnswer.Parameter + ";";
                    Question = Questions.First(x => x.Id == SecondAnswer.IdNextQuestion);
                }
                FirstAnswer = Answers.First(x => x.IdQuestion == Question.Id);
                SecondAnswer = Answers.First(x => x.IdQuestion == Question.Id && x.Id != FirstAnswer.Id);
                questionLabel.Text = Question.QuestionText;
                radioButton1.Text = FirstAnswer.AnswerText;
                radioButton2.Text = SecondAnswer.AnswerText;
            }
            else if((radioButton1.Checked && FirstAnswer.IdNextQuestion == 0) || (radioButton2.Checked && SecondAnswer.IdNextQuestion == 0))
            {
                if (radioButton1.Checked)
                {
                    Result += FirstAnswer.Parameter;
                }
                else
                {
                    Result += SecondAnswer.Parameter;
                }
                Validation validation = new Validation();
                var car = validation.ParseParametersToAttributes(Result, Cars, SimpleRules, ComplexRules);
                questionLabel.Text = "Машина вашей мечты это " + car.Attributes["Марка"] + " " + car.Attributes["Модель"];
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                button.Text = "Начать";
                Result = string.Empty;
                Questions.Clear();
                Answers.Clear();
                Cars.Clear();
                SimpleRules.Clear();
                ComplexRules.Clear();
            }
        }
    }
}
