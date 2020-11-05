using System;
using System.ComponentModel.DataAnnotations.Schema;
using Database;

namespace TAS_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IReadInputChoicesData readObject = new ReadInputChoicesData();
            List<InputChoices> allInputChoices=readObject.GetAllInputChoices();

            foreach(InputChoices choice in allInputChoices){
                Console.WriteLine(choice.ToString());
            }
            Console.WriteLine("Finished.");
        }

        public void Welcome()
        {

        }

        public void Menu ()
        {

        }

        public void AnswerSurvey()
        {

        }

        public void ViewFeedback ()
        {
            
        }
    }
}