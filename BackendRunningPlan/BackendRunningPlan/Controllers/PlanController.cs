using Microsoft.AspNetCore.Mvc;
using BackendRunningPlan.Models;

namespace BackendRunningPlan.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : Controller
    {
        [HttpGet(Name = "GetPlan")]
        public TrainingList Get()
        {
            TrainingList trainingLists = new TrainingList();

            Training training1 = new Training() { Name = "Running1", Description = "Trcanje 10 kilometara, lagan tempo", Note = "puls 130" };
            Training training2 = new Training() { Name = "Teretana", Description = "Teretana 40 minuta", Note = "gornji deo" };

            List<Training> trainingList = new List<Training>();
            trainingList.Add(training1);
            trainingList.Add(training2);

            List<Training> trainingList2 = new List<Training>();
            trainingList2.Add(training1);




            //TrainingDay trDay1 = new TrainingDay() { Id = "1", Number = "1", DateTime = DateTime.Now, Trainings = trainingList };
            //TrainingDay trDay2 = new TrainingDay() { Id = "2", Number = "2", DateTime = DateTime.Now, Trainings = trainingList };
            //TrainingDay trDay3 = new TrainingDay() { Id = "3", Number = "1", DateTime = DateTime.Now, Trainings = trainingList };
            //TrainingDay trDay4 = new TrainingDay() { Id = "4", Number = "2", DateTime = DateTime.Now, Trainings = trainingList };
            //TrainingDay trDay5 = new TrainingDay() { Id = "5", Number = "1", DateTime = DateTime.Now, Trainings = trainingList };
            //TrainingDay trDay6 = new TrainingDay() { Id = "6", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay7 = new TrainingDay() { Id = "7", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay8 = new TrainingDay() { Id = "8", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay9 = new TrainingDay() { Id = "9", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay10 = new TrainingDay() { Id = "10", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay11 = new TrainingDay() { Id = "11", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay12 = new TrainingDay() { Id = "12", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay13 = new TrainingDay() { Id = "13", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay14 = new TrainingDay() { Id = "14", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay15 = new TrainingDay() { Id = "15", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay16 = new TrainingDay() { Id = "16", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay17 = new TrainingDay() { Id = "17", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay18 = new TrainingDay() { Id = "18", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay19 = new TrainingDay() { Id = "19", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay20 = new TrainingDay() { Id = "20", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay21 = new TrainingDay() { Id = "21", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay22 = new TrainingDay() { Id = "22", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay23 = new TrainingDay() { Id = "23", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay24 = new TrainingDay() { Id = "24", Number = "1", DateTime = DateTime.Now, Trainings = trainingList2 };
            //TrainingDay trDay25 = new TrainingDay() { Id = "25", Number = "2", DateTime = DateTime.Now, Trainings = trainingList2 };


            List<TrainingDay> trainingDays = new List<TrainingDay>();
            //trainingDays.Add(trDay1);
            //trainingDays.Add(trDay2);
            //trainingDays.Add(trDay3);
            //trainingDays.Add(trDay4);
            //trainingDays.Add(trDay5);
            //trainingDays.Add(trDay6);
            //trainingDays.Add(trDay7);
            //trainingDays.Add(trDay8);
            //trainingDays.Add(trDay9);
            //trainingDays.Add(trDay10);
            //trainingDays.Add(trDay11);
            //trainingDays.Add(trDay12);
            //trainingDays.Add(trDay13);
            //trainingDays.Add(trDay14);
            //trainingDays.Add(trDay15);
            //trainingDays.Add(trDay16);
            //trainingDays.Add(trDay17);
            //trainingDays.Add(trDay18);
            //trainingDays.Add(trDay19);
            //trainingDays.Add(trDay20);
            //trainingDays.Add(trDay21);
            //trainingDays.Add(trDay22);
            //trainingDays.Add(trDay23);
            //trainingDays.Add(trDay24);
            //trainingDays.Add(trDay25);

            trainingLists = new Models.TrainingList() { Id = 1, Description="Halfmarathon training", TrainingDays = trainingDays };

            return trainingLists;
        }
    }
}

