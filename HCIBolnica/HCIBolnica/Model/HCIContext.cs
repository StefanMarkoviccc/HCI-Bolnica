using HCIBolnica.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIBolnica.Model
{
    public class HCIContext
    {
        private static HCIContext instance = null;
        private List<Entity> anamnezas = new List<Entity>();
        private List<Entity> appointments = new List<Entity>();
        private List<Entity> doctors = new List<Entity>();
        private List<Entity> complains = new List<Entity>();
        private List<Entity> healthCards = new List<Entity>();
        private List<Entity> medicines = new List<Entity>();
        private List<Entity> patients = new List<Entity>();
        private List<Entity> people = new List<Entity>();
        private List<Entity> recipes = new List<Entity>();
        private List<Entity> users = new List<Entity>();
        private List<Entity> rooms = new List<Entity>();
        private List<Entity> spentInventorys = new List<Entity>();
        private List<Entity> requestsForSpecializations = new List<Entity>();
        private List<Entity> requestsToManager = new List<Entity>();
        private List<Entity> requestForSpecialists = new List<Entity>();
        private List<Entity> hospitalTreatments = new List<Entity>();
        private List<Entity> medicnesSupply = new List<Entity>();
        private List<Entity> informationOfPatientAppontment = new List<Entity>();

        public HCIContext()
        {
            
        }

        public static HCIContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HCIContext();
                    instance.Load();
                }
                return instance;
            }
        }

        public List<Entity> RequestToManager
        {
            get { return requestsToManager; }
            set { requestsToManager = value; }
        }

        public List<Entity> RequestsForSpecializations
        {
            get { return requestsForSpecializations; }
            set { requestsForSpecializations = value; }
        }
        public List<Entity> Anamnezas
        {
            get { return anamnezas; }
            set { anamnezas = value; }
        }

        public List<Entity> Appointments
        {
            get { return appointments; }
            set { appointments = value; }
        }
        public List<Entity> Doctors
        {
            get { return doctors; }
            set { doctors = value; }
        }

        public List<Entity> Complains
        {
            get { return complains; }
            set { complains = value; }
        }

        public List<Entity> HealthCards
        {
            get { return healthCards; }
            set { healthCards = value; }
        }

        public List<Entity> Medicines
        {
            get { return medicines; }
            set { medicines = value; }
        }

        public List<Entity> Patients
        {
            get { return patients; }
            set { patients = value; }
        }

        public List<Entity> People
        {
            get { return people; }
            set { people = value; }
        }

        public List<Entity> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public List<Entity> Users
        {
            get { return users; }
            set { users = value; }
        }

        public List<Entity> Rooms
        {
            get { return rooms; }
            set { rooms = value; }
        }

        public List<Entity> SpentInventorys
        {
            get { return spentInventorys; }
            set { spentInventorys = value; }
        }

        public List<Entity> RequestForSpecialists
        {
            get { return requestForSpecialists; }
            set { requestForSpecialists = value; }
        }

        public List<Entity> HospitalTreatments
        {
            get { return hospitalTreatments; }
            set { hospitalTreatments = value; }
        }

        public List<Entity> MedicinesSupply
        {
            get { return medicnesSupply; }
            set { medicnesSupply = value; }
        }
        public List<Entity> InformationOfPatientAppontment
        {
            get { return informationOfPatientAppontment; }
            set { informationOfPatientAppontment = value; }
        }
        public TypeOfAppointment GetTypeOfAppointment(string value)
        {
            if (value == "Operation")
            {
                return TypeOfAppointment.Operation;
            }
            return TypeOfAppointment.Examination;
        }

        public Specialization GetSpecialization(string value)
        {
            if (value == "Cardiologist")
            {
                return Specialization.Cardiologist;
            } else if (value == "Dentist")
            {
                return Specialization.Dentist;
            }
            else if (value == "Dermatologist")
            {
                return Specialization.Dermatologist;
            } else if (value == "Surgeon")
            {
                return Specialization.Surgeon;
            } else if (value == "Neurosurgeon")
            {
                return Specialization.Neurosurgeon;
            } else if (value == "Pediatrician")
            {
                return Specialization.Pediatrician;
            }
            else
            {
                return Specialization.GeneralPractice;
            }
        }

        public RoomType GetRoomType(string value)
        {
            if (value == "OperationalRoom")
            {
                return RoomType.OperationalRoom;
            } else if (value == "ExaminationPoom")
            {
                return RoomType.ExaminationPoom;
            }
            else
            {
                return RoomType.RestRoom;
            }
        }

        public Role GetRole(string value)
        {
            if (value == "Doctor")
            {
                return Role.Doctor;
            } else if (value == "Patient")
            {
                return Role.Patient;
            } else if (value == "Secretary")
            {
                return Role.Secretary;
            }
            else
            {
                return Role.Manager;
            }
        }

        public RequestStatus GetRequestStatus(string value)
        {
            if (value == "New")
            {
                return RequestStatus.New;
            } else if (value == "Acepted")
            {
                return RequestStatus.Accepted;
            }
            else
            {
                return RequestStatus.Rejected;
            }
        }

        public MerrageStatus GetMerrageStatus(string value)
        {
            if (value == "NotMarried")
            {
                return MerrageStatus.NotMarried;
            } else if (value == "Married")
            {
                return MerrageStatus.Married;
            }
            else
            {
                return MerrageStatus.Divorced;
            }
        }

        public Gender GetGender(string value)
        {
            if (value == "Male")
            {
                return Gender.Male;
            }
            else
            {
                return Gender.Female;
            }
        }

        public void SaveDoctor()
        {
            if (doctors == null)
            {
                return;
            }

            using (StreamWriter file = new StreamWriter("doctor.txt"))
            {
                foreach (Entity entity in doctors)
                {
                    string line = string.Empty;

                    line += ((Doctor)entity).ID + "|";
                    line += ((Doctor)entity).FirstName + "|";
                    line += ((Doctor)entity).LastName + "|";
                    line += ((Doctor)entity).JMBG + "|";
                    line += ((Doctor)entity).Email + "|";
                    line += ((Doctor)entity).Specialization + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SavePatient()
        {
            if (patients == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("patient.txt"))
            {
                foreach (Entity entity in patients)
                {
                    string line = string.Empty;

                    line += ((Patient)entity).ID + "|";
                    line += ((Patient)entity).FirstName + "|";
                    line += ((Patient)entity).LastName + "|";
                    line += ((Patient)entity).FullName + "|";
                    line += ((Patient)entity).HealthCard.ID + "|";
                    line += ((Patient)entity).JMBG + "|";
                    line += ((Patient)entity).Anamneza + "|";
                    line += ((Patient)entity).Email + "|";
                    line += ((Patient)entity).Gender + "|";
                    line += ((Patient)entity).Phone + "|";
                    line += ((Patient)entity).DateOfBirth + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SaveAnamneza()
        {
            if (anamnezas == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("anamneza.txt"))
            {
                foreach (Entity entity in anamnezas)
                {
                    string line = string.Empty;

                    line += ((Anamneza)entity).ID + "|";
                    line += ((Anamneza)entity).Patient.ID + "|";
                    line += ((Anamneza)entity).Simptoms + "|";
                    line += ((Anamneza)entity).DoctorReport + "|";
                    line += ((Anamneza)entity).DateOfPreviousAppointment + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SaveAppointment()
        {
            if (appointments == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("appointment.txt"))
            {
                foreach (Entity entity in appointments)
                {
                    string line = string.Empty;
                    line += ((Appointment)entity).Time + "|";
                    line += ((Appointment)entity).DurationOfTheAppointment + "|";
                    line += ((Appointment)entity).DateOfAppointment + "|";
                    line += ((Appointment)entity).TypeOfAppointment + "|";
                    line += ((Appointment)entity).ID + "|";
                    line += ((Appointment)entity).Room + "|";
                    line += ((Appointment)entity).Patient.ID + "|";
                    line += ((Appointment)entity).IsUrgent + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SaveHealthCard()
        {
            if (healthCards == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("healthCard.txt"))
            {
                foreach (Entity entity in healthCards)
                {
                    string line = string.Empty;
                    line += ((HealthCard)entity).ReceptionDepartment + "|";
                    line += ((HealthCard)entity).FirstName + "|";
                    line += ((HealthCard)entity).LastName + "|";
                    line += ((HealthCard)entity).ParentName + "|";
                    line += ((HealthCard)entity).DateOfBirth + "|";
                    line += ((HealthCard)entity).Gender + "|";
                    line += ((HealthCard)entity).Phone + "|";
                    line += ((HealthCard)entity).ID + "|";
                    line += ((HealthCard)entity).MerrageStatus + "|";
                    line += ((HealthCard)entity).Anamneza + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SaveComplain()
        {
            if (complains == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("complain.txt"))
            {
                foreach (Entity entity in complains)
                {
                    string line = string.Empty;
                    line += ((Complain)entity).ID + "|";
                    line += ((Complain)entity).ComplainText + "|";
                    line += ((Complain)entity).MedicationId + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SaveMedicine()
        {
            if(medicines == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("medicine.txt"))
            {
                foreach(Entity entity in medicines)
                {
                    string line = string.Empty;
                    line += ((Medicine)entity).ID + "|";
                    line += ((Medicine)entity).MedicineName + "|";
                    line += ((Medicine)entity).QuantityOfMedicine + "|";
                    line += ((Medicine)entity).PeriodOfTakingTheDrug + "|";
                    line += ((Medicine)entity).StartOfTherapy + "|";
                    line += ((Medicine)entity).EndOfTherapy + "|";
                    line += ((Medicine)entity).DrugIngredients + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SavePerson()
        {
            if (people == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("person.txt"))
            {
                foreach (Entity entity in people)
                {
                    string line = string.Empty;
                    line += ((Person)entity).ID + "|";
                    line += ((Person)entity).FirstName + "|";
                    line += ((Person)entity).LastName + "|";
                    line += ((Person)entity).JMBG + "|";
                    line += ((Person)entity).Email + "|";
                    line += ((Person)entity).FullName + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SaveRecipe()
        {
            if (recipes == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("recipe.txt"))
            {
                foreach (Entity entity in recipes)
                {
                    string line = string.Empty;
                    line += ((Recipe)entity).ID + "|";
                    line += ((Recipe)entity).Medicine.ID + "|";
                    line += ((Recipe)entity).QuantityOfTherapy + "|";
                    line += ((Recipe)entity).MedicineStrength + "|";
                    line += ((Recipe)entity).BeginningOfTherapy + "|";
                    line += ((Recipe)entity).EndOfTherapy + "|";
                    line += ((Recipe)entity).TakingMedicineInHours + "|";
                    line += ((Recipe)entity).PatientId + "|";
                  
                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SaveUser()
        {
            if (users == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("user.txt"))
            {
                foreach (Entity entity in users)
                {
                    string line = string.Empty;
                    line += ((User)entity).UserName + "|";
                    line += ((User)entity).Password + "|";
                  
                    file.WriteLine(line);
                }
                file.Close();

            }
        }
        public void SaveRoom()
        {
            if (rooms == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("room.txt"))
            {
                foreach (Entity entity in rooms)
                {
                    string line = string.Empty;
                    line += ((Room)entity).RoomType + "|";
                    line += ((Room)entity).ID + "|";
                    line += ((Room)entity).Busy + "|";

                    file.WriteLine(line);
                }
                file.Close();

            }
        }

        public void SaveSpentInventory()
        {
            if (spentInventorys == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("spentInventory.txt"))
            {
                foreach (Entity entity in spentInventorys)
                {
                    string line = string.Empty;
                    line += ((SpentInventory)entity).ID + '|';
                    line += ((SpentInventory)entity).InventoryName + "|";
                    line += ((SpentInventory)entity).InventoryQuantity + "|";
                   

                    file.WriteLine(line);
                }
                    file.Close();
            }
        }

        private void SaveRequestForSpecialization()
        {
            if(requestsForSpecializations == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("requestForSpecialization.txt"))
            {
                foreach(Entity entity in requestsForSpecializations)
                {
                    string line = string.Empty;
                    line += ((RequestForSpecializationModel)entity).Doctor.ID + "|";
                    line += ((RequestForSpecializationModel)entity).Specialization + "|";

                    file.WriteLine(line);
                }
                file.Close();
            }
        }

        private void SaveVacationRequest()
        {
            if (requestsToManager == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("vacationRequest.txt"))
            {
                foreach (Entity entity in requestsToManager)
                {
                    string line = string.Empty;
                    line += ((RequestToManager)entity).ID + "|";
                    line += ((RequestToManager)entity).Doctor + "|";
                    line += ((RequestToManager)entity).BeginningOfHoliday + "|";
                    line += ((RequestToManager)entity).EndOfHoliday + "|";
                    line += ((RequestToManager)entity).RequestDescription + "|";

                    file.WriteLine(line);
                }
                file.Close();
            }
        }

        private void SaveRequestForSpecialist()
        {
            if (requestForSpecialists == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("requestForSpecialist.txt"))
            {
                foreach (Entity entity in requestForSpecialists)
                {
                    string line = string.Empty;
                    line += ((RequestForSpecialistModel)entity).ID + "|";
                    line += ((RequestForSpecialistModel)entity).Specialization + "|";
                    line += ((RequestForSpecialistModel)entity).HealthCardNumber + "|";
                    line += ((RequestForSpecialistModel)entity).JMBG + "|";
                    line += ((RequestForSpecialistModel)entity).ReasonForSpecialist + "|";

                    file.WriteLine(line);
                }
                file.Close();
            }
        }

        private void SaveHospitalTreatment()
        {
            if (hospitalTreatments == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("hospitalTreatment.txt"))
            {
                foreach (Entity entity in hospitalTreatments)
                {
                    string line = string.Empty;
                    line += ((HospitalTreatmentModel)entity).ID + "|";
                    line += ((HospitalTreatmentModel)entity).Patient + "|";
                    line += ((HospitalTreatmentModel)entity).HealthCardNumber + "|";
                    line += ((HospitalTreatmentModel)entity).Diagosis + "|";
                   
                    file.WriteLine(line);
                }
                file.Close();
            }
        }

        private void SaveRequestForMedicineSupply()
        {
            if (medicnesSupply == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("requestForMedicineSupply.txt"))
            {
                foreach (Entity entity in medicnesSupply)
                {
                    string line = string.Empty;
                    line += ((RequestForMedicinesSupplyModel)entity).ID + "|";
                    line += ((RequestForMedicinesSupplyModel)entity).Doctor + "|";
                    line += ((RequestForMedicinesSupplyModel)entity).Medicine + "|";
                    line += ((RequestForMedicinesSupplyModel)entity).Reason + "|";

                    file.WriteLine(line);
                }
                file.Close();
            }
        }
        private void SaveInformationOfPatientAppointment()
        {
            if (informationOfPatientAppontment == null)
            {
                return;
            }
            using (StreamWriter file = new StreamWriter("informationOfPatientAppontment.txt"))
            {
                foreach (Entity entity in informationOfPatientAppontment)
                {
                    string line = string.Empty;
                    line += ((InformationOfPatientAppointmentModel)entity).Anamneza + "|";
                    line += ((InformationOfPatientAppointmentModel)entity).Diagnosis + "|";
                    line += ((InformationOfPatientAppointmentModel)entity).Therapy + "|";
                    line += ((InformationOfPatientAppointmentModel)entity).Control + "|";

                    file.WriteLine(line);
                }
                file.Close();
            }
        }

        public void LoadDoctor()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("doctor.txt"))
            {
                doctors = result;
                return;
            }

            StreamReader reader = new StreamReader("doctor.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Doctor doctor = new Doctor();
                doctor.ID = data[0];        
                doctor.FirstName = data[1];
                doctor.LastName = data[2];
                doctor.JMBG = data[3];
                doctor.Email = data[4];
                doctor.Specialization = GetSpecialization(data[5]);

                result.Add(doctor);
            }
            reader.Close();
            doctors = result;
        }

        public void LoadPatient()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("patient.txt"))
            {
                patients = result;
                return;
            }

            StreamReader reader = new StreamReader("patient.txt");
            string line;

            HealthCardsRepository repository = new HealthCardsRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Patient patient = new Patient();
                patient.ID = data[0];
                patient.FirstName = data[1];
                patient.LastName = data[2];
                patient.FullName = data[3];
                patient.HealthCard = repository.Get(data[4]) as HealthCard;
                patient.JMBG = data[5];
                patient.Anamneza = data[6];
                patient.Email = data[7];
                patient.Gender = GetGender(data[8]);
                patient.Phone = data[9];
                patient.DateOfBirth = DateTime.Parse(data[10]);

                result.Add(patient);
            }
            reader.Close();
            patients = result;
        }

        public void LoadAnamneza()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("anamneza.txt"))
            {
                anamnezas = result;
                return;
            }

            StreamReader reader = new StreamReader("anamneza.txt");
            string line;
            PatientRepository patientRepository = new PatientRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Anamneza anamneza = new Anamneza();
                anamneza.ID = data[0];
                anamneza.Patient = patientRepository.Get(data[1]) as Patient;
                anamneza.Simptoms = data[2];
                anamneza.DoctorReport = data[3];
                anamneza.DateOfPreviousAppointment = DateTime.Parse(data[4]);

                result.Add(anamneza);
            }
            reader.Close();
            anamnezas = result;
        }

        public void LoadAppointment()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("appointment.txt"))
            {
                appointments = result;
                return;
            }

            StreamReader reader = new StreamReader("appointment.txt");
            string line;
            PatientRepository patientRepository = new PatientRepository();
            RoomRepository roomRepository = new RoomRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Appointment appointment = new Appointment();
                appointment.Time = data[0];
                appointment.DurationOfTheAppointment = Double.Parse(data[1]);
                appointment.DateOfAppointment = DateTime.Parse(data[2]);
                appointment.TypeOfAppointment = GetTypeOfAppointment(data[3]);
                appointment.ID = data[4];
                appointment.Room = roomRepository.Get(data[5]) as Room;
                appointment.Patient = patientRepository.Get(data[6]) as Patient;
                appointment.IsUrgent = bool.Parse(data[7]);

                result.Add(appointment);
            }
            reader.Close();
            appointments = result;
        }

        public void LoadHealthCard()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("healthCard.txt"))
            {
                healthCards = result;
                return;
            }

            StreamReader reader = new StreamReader("healthCard.txt");
            string line;
            AnamnezaRepository anamnezaRepository = new AnamnezaRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                HealthCard healthCard = new HealthCard();
                healthCard.ReceptionDepartment = data[0];
                healthCard.FirstName = data[1];
                healthCard.LastName = data[2];
                healthCard.ParentName = data[3];
                healthCard.DateOfBirth = DateTime.Parse(data[4]);
                healthCard.Gender = GetGender(data[5]);
                healthCard.Phone = data[6];
                healthCard.ID = data[7];
                healthCard.MerrageStatus = GetMerrageStatus(data[8]);
                healthCard.Anamneza = anamnezaRepository.Get(data[9]) as Anamneza;

                result.Add(healthCard);
            }
            reader.Close();
            healthCards = result;
        }

        public void LoadComplain()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("complain.txt"))
            {
                complains = result;
                return;
            }

            StreamReader reader = new StreamReader("complain.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Complain complain = new Complain();
                complain.ID = data[0];
                complain.ComplainText = data[1];
                complain.MedicationId = data[2];

                result.Add(complain);
            }
            reader.Close();
            complains = result;
        }

        public void LoadMedicine()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("medicine.txt"))
            {
                medicines = result;
                return;
            }

            StreamReader reader = new StreamReader("medicine.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Medicine medicine = new Medicine();
                medicine.ID = data[0];
                medicine.MedicineName = data[1];
                medicine.QuantityOfMedicine = data[2];
                medicine.PeriodOfTakingTheDrug = data[3];
                medicine.StartOfTherapy = DateTime.Parse(data[4]);
                medicine.EndOfTherapy = DateTime.Parse(data[5]);
                medicine.DrugIngredients = data[6];

                result.Add(medicine);
            }
            reader.Close();
            medicines = result;
        }
        public void LoadPerson()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("person.txt"))
            {
                people = result;
                return;
            }

            StreamReader reader = new StreamReader("person.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Person person = new Person();
                person.FirstName = data[0];
                person.LastName = data[1];
                person.JMBG = data[2];
                person.Email = data[3];
                person.FullName = data[4];

                result.Add(person);
            }
            reader.Close();
            people = result;
        }
        public void LoadRecepie()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("recipe.txt"))
            {
                recipes = result;
                return;
            }

            StreamReader reader = new StreamReader("recipe.txt");
            string line;
            MedicineRepository medicineRepository = new MedicineRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Recipe recipe = new Recipe();
                recipe.ID = data[0];
                recipe.Medicine = medicineRepository.Get(data[1]) as Medicine;
                recipe.QuantityOfTherapy = data[2];
                recipe.MedicineStrength = data[3];
                recipe.BeginningOfTherapy = DateTime.Parse(data[4]);
                recipe.EndOfTherapy = DateTime.Parse(data[5]);
                recipe.TakingMedicineInHours = double.Parse(data[6]);
                recipe.PatientId = data[7];

                result.Add(recipe);
            }
            reader.Close();
            recipes = result;
        }
        public void LoadUser()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("user.txt"))
            {
                users = result;
                return;
            }

            StreamReader reader = new StreamReader("user.txt");
            string line;
            PersonRepository personRepository = new PersonRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                User user = new User();
                user.UserName = data[0];
                user.Password = data[1];

                result.Add(user);
            }
            reader.Close();
            users = result;
        }

        public void LoadRoom()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("room.txt"))
            {
                rooms = result;
                return;
            }

            StreamReader reader = new StreamReader("room.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                Room room = new Room();
                room.RoomType = GetRoomType(data[0]);
                room.ID = data[1];
                room.Busy = bool.Parse(data[2]);

                result.Add(room);
            }
            reader.Close();
            rooms = result;
        }

        public void LoadSpentInventory()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("spentInventory.txt"))
            {
                spentInventorys = result;
                return;
            }

            StreamReader reader = new StreamReader("spentInventory.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                SpentInventory spentInventory = new SpentInventory();
                spentInventory.ID = data[0];
                spentInventory.InventoryName = data[1];
                spentInventory.InventoryQuantity = data[2];

                result.Add(spentInventory);
            }
            reader.Close();
            spentInventorys = result;
        }
        public void LoadRequesForSpecialization()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("requestForSpecialization.txt"))
            {
                requestsForSpecializations = result;
                return;
            }

            StreamReader reader = new StreamReader("requestForSpecialization.txt");
            string line;
            DoctorRepository doctorRepository = new DoctorRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                RequestForSpecializationModel requestForSpecialization = new RequestForSpecializationModel();
                requestForSpecialization.Doctor = doctorRepository.Get(data[0]) as Doctor;
                requestForSpecialization.Specialization = GetSpecialization(data[1]);

                result.Add(requestForSpecialization);
            }
            reader.Close();
            requestsForSpecializations = result;
        }

        public void LoadVacationRequest()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("vacationRequest.txt"))
            {
                requestsToManager = result;
                return;
            }

            StreamReader reader = new StreamReader("vacationRequest.txt");
            string line;
            DoctorRepository doctorRepository = new DoctorRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                RequestToManager requestToManager = new RequestToManager();
                requestToManager.ID = data[0];
                requestToManager.Doctor = doctorRepository.Get(data[1]) as Doctor;
                requestToManager.BeginningOfHoliday = DateTime.Parse(data[2]);
                requestToManager.EndOfHoliday = DateTime.Parse(data[3]);
                requestToManager.RequestDescription = data[4];

                result.Add(requestToManager);
            }
            reader.Close();
            requestsToManager = result;
        }

        public void LoadRequestForSpecialist()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("requestForSpecialist.txt"))
            {
                requestForSpecialists = result;
                return;
            }

            StreamReader reader = new StreamReader("requestForSpecialist.txt");
            string line;
            HealthCardsRepository healthCardsRepository = new HealthCardsRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                RequestForSpecialistModel requestForSpecialist = new RequestForSpecialistModel();
                requestForSpecialist.ID = data[0];
                requestForSpecialist.Specialization = GetSpecialization(data[1]);
                requestForSpecialist.HealthCardNumber = data[2];
                requestForSpecialist.JMBG = data[3];
                requestForSpecialist.ReasonForSpecialist = data[4];

                result.Add(requestForSpecialist);
            }
            reader.Close();
            requestForSpecialists = result;
        }

        public void LoadHospitalTreatment()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("hospitalTreatment.txt"))
            {
                requestForSpecialists = result;
                return;
            }

            StreamReader reader = new StreamReader("hospitalTreatment.txt");
            string line;
            PatientRepository patientRepository = new PatientRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                HospitalTreatmentModel hospitalTreatmentModel = new HospitalTreatmentModel();
                hospitalTreatmentModel.ID = data[0];
                hospitalTreatmentModel.Patient
                    = patientRepository.Get(data[1]) as Patient;
                hospitalTreatmentModel.HealthCardNumber = data[2];
                hospitalTreatmentModel.Diagosis = data[3];

                result.Add(hospitalTreatmentModel);
            }
            reader.Close();
            hospitalTreatments = result;
        }

        public void LoadRequestForMedicineSupply()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("requestForMedicineSupply.txt"))
            {
                medicnesSupply = result;
                return;
            }

            StreamReader reader = new StreamReader("requestForMedicineSupply.txt");
            string line;
            DoctorRepository doctorRepository = new DoctorRepository();
            MedicineRepository medicineRepository = new MedicineRepository();

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                RequestForMedicinesSupplyModel requestForMedicineSupply= new RequestForMedicinesSupplyModel();
                requestForMedicineSupply.ID = data[0];
                requestForMedicineSupply.Doctor = doctorRepository.Get(data[1]) as Doctor;
                requestForMedicineSupply.Medicine = medicineRepository.Get(data[2]) as Medicine;
                requestForMedicineSupply.Reason = data[3];

                result.Add(requestForMedicineSupply);
            }
            reader.Close();
            medicnesSupply = result;
        }
        public void LoadInformationOfPatientAppointments()
        {
            List<Entity> result = new List<Entity>();
            if (!File.Exists("informationOfPatientAppontment.txt"))
            {
                informationOfPatientAppontment = result;
                return;
            }

            StreamReader reader = new StreamReader("informationOfPatientAppontment.txt");
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split('|');
                InformationOfPatientAppointmentModel informationOfPatientAppontment = new InformationOfPatientAppointmentModel();
                informationOfPatientAppontment.Anamneza = data[0];
                informationOfPatientAppontment.Diagnosis = data[1];
                informationOfPatientAppontment.Therapy = data[2];
                informationOfPatientAppontment.Control = data[3];

                result.Add(informationOfPatientAppontment);
            }
            reader.Close();
            informationOfPatientAppontment = result;
        }

        public List<Entity> Get(Type type)
        {
            if(type == typeof(Doctor))
            {
                return Doctors;
            }

            if (type == typeof(Patient))
            {
                return Patients;
            }

            if (type == typeof(Anamneza))
            {
                return Anamnezas;
            }

            if (type == typeof(Appointment))
            {
                return Appointments;
            }

            if (type == typeof(HealthCard))
            {
                return HealthCards;
            }

            if (type == typeof(Complain))
            {
                return Complains;
            }

            if (type == typeof(Medicine))
            {
                return Medicines;
            }

            if (type == typeof(Person))
            {
                return People;
            }

            if (type == typeof(Recipe))
            {
                return Recipes;
            }

            if (type == typeof(User))
            {
                return Users;
            }

            return Rooms;
        }

        public void Set(Type type, List<Entity> entities)
        {
            if(type == typeof(Doctor))
            {
                Doctors = entities;
                return;
            }

            if (type == typeof(Patient))
            {
                Patients = entities;
                return;
            }

            if (type == typeof(Anamneza))
            {
                Anamnezas = entities;
                return;
            }

            if (type == typeof(Appointment))
            {
                Appointments = entities;
                return;
            }

            if (type == typeof(HealthCard))
            {
                HealthCards = entities;
                return;
            }

            if (type == typeof(Complain))
            {
                Complains = entities;
                return;
            }

            if (type == typeof(Medicine))
            {
                Medicines = entities;
                return;
            }

            if (type == typeof(Person))
            {
                People = entities;
                return;
            }

            if (type == typeof(Recipe))
            {
                Recipes = entities;
                return;
            }

            if (type == typeof(User))
            {
                Users = entities;
                return;
            }

            Rooms = entities;
        }

        public void Load()
        {
            LoadHealthCard();
            LoadRoom();
            LoadDoctor();
            LoadPatient();
            LoadAnamneza();
            LoadAppointment();
            LoadRequesForSpecialization();
            LoadVacationRequest();
            LoadSpentInventory();
            LoadRequestForMedicineSupply();
            LoadComplain();
            LoadMedicine();
            LoadRequestForSpecialist();
            LoadHospitalTreatment();
            LoadPerson();
            LoadRecepie();
            LoadUser();
            LoadInformationOfPatientAppointments();
        }

        public void Save()
        {
            SaveDoctor();
            SavePatient();
            SaveAnamneza();
            SaveAppointment();
            SaveHealthCard();
            SaveRequestForSpecialization();
            SaveVacationRequest();
            SaveComplain();
            SaveSpentInventory();
            SaveRequestForMedicineSupply();
            SaveMedicine();
            SaveRequestForSpecialist();
            SaveHospitalTreatment();
            SavePerson();
            SaveRecipe();
            SaveUser();
            SaveRoom();
            SaveInformationOfPatientAppointment();
        }
    }
}
