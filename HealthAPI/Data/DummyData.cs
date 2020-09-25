using System;
using System.Collections.Generic;
using System.Linq;
using HealthAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace HealthAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<HealthContext>();
                context.Database.EnsureCreated();

                var clinicians = DummyData.GetClinicians().ToArray();
                context.Clinicians.AddRange(clinicians);
                context.SaveChanges();

                var medicines = DummyData.GetMedicines().ToArray();
                context.Medicines.AddRange(medicines);
                context.SaveChanges();

                var patients = DummyData.GetPatients().ToArray();
                context.Patients.AddRange(patients);
                context.SaveChanges();

                var bloodPressures = DummyData.GetBloodPressures().ToArray();
                context.BloodPressures.AddRange(bloodPressures);
                context.SaveChanges();

                var bodyHeats = DummyData.GetBodyHeats().ToArray();
                context.BodyHeats.AddRange(bodyHeats);
                context.SaveChanges();

                var respiratoryRates = DummyData.GetRespiratoryRates().ToArray();
                context.RespiratoryRates.AddRange(respiratoryRates);
                context.SaveChanges();

                var sinusRhythms = DummyData.GetSinusRhythms().ToArray();
                context.SinusRhythms.AddRange(sinusRhythms);
                context.SaveChanges();

                var appointments = DummyData.GetAppointments().ToArray();
                context.Appointments.AddRange(appointments);
                context.SaveChanges();

                var watchLists = DummyData.GetWatchLists().ToArray();
                context.WatchLists.AddRange(watchLists);
                context.SaveChanges();

                var images = DummyData.GetImages().ToArray();
                context.Images.AddRange(images);
                context.SaveChanges();

                var diagnoses = DummyData.GetDiagnoses().ToArray();
                context.Diagnoses.AddRange(diagnoses);
                context.SaveChanges();

                var observedItems = DummyData.GetObservedItems(context).ToArray();
                context.ObservedItems.AddRange(observedItems);
                context.SaveChanges();

                var observations = DummyData.GetObservations(context).ToArray();
                context.Observations.AddRange(observations);
                context.SaveChanges();

                var medications = DummyData.GetMedications(context).ToArray();
                context.Medications.AddRange(medications);
                context.SaveChanges();

                var reports = DummyData.GetReports(context).ToArray();
                context.Reports.AddRange(reports);
                context.SaveChanges();

                
            }
        }

        public static List<BloodPressure> GetBloodPressures()
        {
            List<BloodPressure> bloodPressures = new List<BloodPressure>()
            {
                new BloodPressure
                {
                    ID = "BP0001",
                    Item = "Blood Pressure",
                    Value = "120/65",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0002",
                    Item = "Blood Pressure",
                    Value = "105/75",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0003",
                    Item = "Blood Pressure",
                    Value = "95/80",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0004",
                    Item = "Blood Pressure",
                    Value = "100/72",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0005",
                    Item = "Blood Pressure",
                    Value = "130/69",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0006",
                    Item = "Blood Pressure",
                    Value = "100/72",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0007",
                    Item = "Blood Pressure",
                    Value = "112/85",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0008",
                    Item = "Blood Pressure",
                    Value = "121/82",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0009",
                    Item = "Blood Pressure",
                    Value = "98/77",
                    Unit = "mmHg",
                },
                new BloodPressure
                {
                    ID = "BP0010",
                    Item = "Blood Pressure",
                    Value = "94/69",
                    Unit = "mmHg",
                },
            };
            return bloodPressures;
        }

        public static List<BodyHeat> GetBodyHeats()
        {
            List<BodyHeat> bodyHeats = new List<BodyHeat>()
            {
                new BodyHeat
                {
                    ID = "BH0001",
                    Item = "Body Heat",
                    Value = "36.5",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0002",
                    Item = "Body Heat",
                    Value = "37",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0003",
                    Item = "Body Heat",
                    Value = "36.6",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0004",
                    Item = "Body Heat",
                    Value = "36.3",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0005",
                    Item = "Body Heat",
                    Value = "37.1",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0006",
                    Item = "Body Heat",
                    Value = "36.4",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0007",
                    Item = "Body Heat",
                    Value = "36.7",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0008",
                    Item = "Body Heat",
                    Value = "37.2",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0009",
                    Item = "Body Heat",
                    Value = "36.4",
                    Unit = "degree Celsius",
                },
                new BodyHeat
                {
                    ID = "BH0010",
                    Item = "Body Heat",
                    Value = "37.1",
                    Unit = "degree Celsius",
                },
            };
            return bodyHeats;
        }

        public static List<RespiratoryRate> GetRespiratoryRates()
        {
            List<RespiratoryRate> respiratoryRates = new List<RespiratoryRate>()
            {
                new RespiratoryRate
                {
                    ID = "RR0001",
                    Item = "Respiratory Rate",
                    Value = "16",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0002",
                    Item = "Respiratory Rate",
                    Value = "17",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0003",
                    Item = "Respiratory Rate",
                    Value = "18",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0004",
                    Item = "Respiratory Rate",
                    Value = "19",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0005",
                    Item = "Respiratory Rate",
                    Value = "20",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0006",
                    Item = "Respiratory Rate",
                    Value = "17",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0007",
                    Item = "Respiratory Rate",
                    Value = "18",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0008",
                    Item = "Respiratory Rate",
                    Value = "16",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0009",
                    Item = "Respiratory Rate",
                    Value = "19",
                    Unit = "breathes/min",
                },
                new RespiratoryRate
                {
                    ID = "RR0010",
                    Item = "Respiratory Rate",
                    Value = "17",
                    Unit = "breathes/min",
                },
            };
            return respiratoryRates;
        }

        public static List<SinusRhythm> GetSinusRhythms()
        {
            List<SinusRhythm> sinusRhythms = new List<SinusRhythm>()
            {
                new SinusRhythm
                {
                    ID = "SR0001",
                    Item = "Sinus Rhythm",
                    Value = "82",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0002",
                    Item = "Sinus Rhythm",
                    Value = "95",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0003",
                    Item = "Sinus Rhythm",
                    Value = "74",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0004",
                    Item = "Sinus Rhythm",
                    Value = "68",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0005",
                    Item = "Sinus Rhythm",
                    Value = "89",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0006",
                    Item = "Sinus Rhythm",
                    Value = "77",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0007",
                    Item = "Sinus Rhythm",
                    Value = "82",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0008",
                    Item = "Sinus Rhythm",
                    Value = "85",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0009",
                    Item = "Sinus Rhythm",
                    Value = "94",
                    Unit = "beats/min",
                },
                new SinusRhythm
                {
                    ID = "SR0010",
                    Item = "Sinus Rhythm",
                    Value = "79",
                    Unit = "beats/min",
                },
            };
            return sinusRhythms;
        }

        public static List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = new List<Appointment>()
            {
                new Appointment
                {
                    AppointmentId = "A0004",
                    Date = "2021-2-20",
                    Time = "10:00:00",
                    Event = "Treatment",
                    Department = "Eye",
                    Floor = "Third Floor",
                    Room = "Room 305",
                    ClinicianId = "C0001",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747"
                },
                new Appointment
                {
                    AppointmentId = "A0001",
                    Date = "2020-1-20",
                    Time = "10:00:00",
                    Event = "Treatment",
                    Department = "Eye",
                    Floor = "Third Floor",
                    Room = "Room 305",
                    ClinicianId = "C0001",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747"
                },
                new Appointment
                {
                    AppointmentId = "A0002",
                    Date = "2020-1-27",
                    Time = "14:00:00",
                    Event = "Test",
                    Department = "Skin",
                    Floor = "Second Floor",
                    Room = "Room 208",
                    ClinicianId = "C0002",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747"
                },
                new Appointment
                {
                    AppointmentId = "A0003",
                    Date = "2020-2-24",
                    Time = "15:30:00",
                    Event = "Test",
                    Department = "Orthotics",
                    Floor = "Fifth Floor",
                    Room = "Room 502",
                    ClinicianId = "C0003",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747"
                }
            };
            return appointments;
        }

        public static List<Observation> GetObservations(HealthContext db)
        {
            Random rnd = new Random();
            List<Observation> observations = new List<Observation>()
            {
                new Observation
                {
                    ObservationId = "O0001",
                    Date = "2020-08-12",
                    Time = "08:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0002",
                    Date = "2020-08-11",
                    Time = "10:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(1).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0003",
                    Date = "2020-08-11",
                    Time = "16:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(2).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0004",
                    Date = "2020-08-05",
                    Time = "10:00:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(3).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0005",
                    Date = "2020-08-05",
                    Time = "08:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(4).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0006",
                    Date = "2020-08-02",
                    Time = "14:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(5).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0007",
                    Date = "2020-03-12",
                    Time = "17:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(6).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0008",
                    Date = "2020-01-09",
                    Time = "13:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(7).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0009",
                    Date = "2019-08-24",
                    Time = "11:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(8).Take(1)),
                },
                new Observation
                {
                    ObservationId = "O0010",
                    Date = "2018-11-02",
                    Time = "16:30:00",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    observedItems = new List<ObservedItem>(db.ObservedItems.Skip(9).Take(1)),
                },
            };
            return observations;
        }

        public static List<ObservedItem> GetObservedItems(HealthContext db)
        {
            Random rnd = new Random();
            List<ObservedItem> observedItems = new List<ObservedItem>()
            {
                
                new ObservedItem
                {
                    ObservedItemId = "OI0001",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0002",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(1).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(1).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(1).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(1).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0003",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(2).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(2).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(2).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(2).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0004",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(3).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(3).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(3).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(3).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0005",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(4).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(4).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(4).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(4).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0006",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(5).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(5).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(5).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(5).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0007",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(6).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(6).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(6).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(6).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0008",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(7).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(7).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(7).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(7).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0009",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(8).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(8).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(8).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(8).Take(1)),
                },
                new ObservedItem
                {
                    ObservedItemId = "OI0010",
                    bloodPressures = new List<BloodPressure>(db.BloodPressures.Skip(9).Take(1)),
                    bodyHeats = new List<BodyHeat>(db.BodyHeats.Skip(9).Take(1)),
                    respiratoryRates = new List<RespiratoryRate>(db.RespiratoryRates.Skip(9).Take(1)),
                    sinusRhythms = new List<SinusRhythm>(db.SinusRhythms.Skip(9).Take(1)),
                },
            };
            return observedItems;
        }

        public static List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>()
            {
                new Patient
                {
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    ImgUrl = "https://images.generated.photos/9upj33g0oUYSIiqywbPwlliMJAyD7uXyqOgRdTGDTyw/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzAyNTU1NjMuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "b905139e-1601-403c-9d85-f8e3997cdd19",
                    ImgUrl = "https://images.generated.photos/LhhwSbqS3dKY0tpV62lgrhNoB4L-UiE0ca2fuw0mBJc/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA1ODc2NDAuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "d9eb4cf6-2894-4627-b912-bbdca07b0401",
                    ImgUrl = "https://images.generated.photos/51yLHYiEIluW1YgPieIaSqwd1L3z5hz-sTxJqpkDrRI/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA5NjIwODkuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "ac529235-6fbc-48f0-a3fa-de7f1924d497",
                    ImgUrl = "https://images.generated.photos/QYcoQepQI9Y4QOuKCDo4wzL1xqfsf_-j7Ip-_l7QIII/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA4Mjk3MTcuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "cc0acce0-30e1-40b8-911a-aa33dc094706",
                    ImgUrl = "https://images.generated.photos/Pcia4pjbp_-6wvZPmsq_GUHsoe5164qzbFgGDytgBZc/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA0MDQ0NjEuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "fabeac89-3134-4afe-b8c4-b3e8004b5d11",
                    ImgUrl = "https://images.generated.photos/fdCPSWyvLZnQgt76oGTTWp16f8rDef6wkdNNxGX51Bs/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA3Mzc3ODcuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "c0c5a342-5a04-4f91-a38d-1b23ad1f5058",
                    ImgUrl = "https://images.generated.photos/iIQXAIVMFmqYANRJCWcN35yh1fhL4niS2EVNHVP9qig/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzAzMDgxNzIuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "32bcb68a-a9f0-42f5-9a7a-ddb4f31e25e8",
                    ImgUrl = "https://images.generated.photos/FjzJ0Q76laUuHkqZXPwtSekdA3RJlpym_Nz4etGTGF0/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA2NjI5MjYuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "58a08e4e-cc5b-4ffa-958b-4829ff0ba010",
                    ImgUrl = "https://images.generated.photos/Hy9E6z_DxSD__KapJFp_L9HAQuWnMR0MGHaU6Ewib2g/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA5NzA4NDQuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "fea08173-18e9-41d9-9f20-d9187ec906c0",
                    ImgUrl = "https://images.generated.photos/HLiQ2Di160xdq9FDCLhqcFlCeF8j2A06r7zANSBEYk0/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA3NzYxMjQuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "49df1158-093c-47c4-85c7-5b297093880e",
                    ImgUrl = "https://images.generated.photos/jSsv80g7qNEgObY0a9oBSZBIqZo7F1z9lKBvv6crCIA/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzAzNjMzMDNfMDEw/MjUzM18wNzE2NTUy/LmpwZw.jpg",
                },
                new Patient
                {
                    PatientId = "dc8d21db-09d4-46be-a0fe-b4608d8dfbb1",
                    ImgUrl = "https://images.generated.photos/VaIjcbwRJKu-E9wzv1VO7-9UFukYyA4kU1qHnPFTLIs/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA2Njk3NjcuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "d519c1e7-42b1-465d-9628-982701d83fef",
                    ImgUrl = "https://images.generated.photos/OYlyxArVWOVTsZ8UVrBLSFEOGVrXkGZ9yHmxXjfInq4/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzAzNjU0MTUuanBn.jpg",
                },new Patient
                {
                    PatientId = "aa0c4f0f-6a93-4f65-a9a9-2faf189d24d9",
                    ImgUrl = "https://images.generated.photos/yo27lDCKHUTXcoYF4Qt7S6yqM6b9oGHiXaFmmOcwyyE/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzAzNzIxNTQuanBn.jpg",
                },
                new Patient
                {
                    PatientId = "1d1629a3-2458-4fba-9a79-97dd0830dbe1",
                    ImgUrl = "https://images.generated.photos/e_FkItTNr6xxvIjAz3TBEczFTvVfsujjFtXljSEjpAw/rs:fit:512:512/Z3M6Ly9nZW5lcmF0/ZWQtcGhvdG9zL3Yz/XzA1NzgyODAuanBn.jpg",
                }
            };
            return patients;
        }

        public static List<WatchList> GetWatchLists()
        {
            List<WatchList> watchLists = new List<WatchList>()
            {
                new WatchList
                {
                    ClinicianId = "C0001",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                }
            };
            return watchLists;
        }

        public static List<Clinician> GetClinicians()
        {
            List<Clinician> clinicians = new List<Clinician>()
            {
                new Clinician
                {
                    ClinicianId = "C0001",
                    ClinicianName = "Joseph Woods",
                    Password = "123456",
                    Email = "yifan.lou@ucl.ac.uk",
                }
            };
            return clinicians;
        }

        public static List<Report> GetReports(HealthContext db)
        {
            Random rnd = new Random();
            List<Report> reports = new List<Report>()
            {
                new Report
                {
                    ReportId = "R0001",
                    Datetime = "2020-08-01 13:22:05",
                    PatientId = "8f789d0b-3145-4cf2-8504-13159edaa747",
                    Images = new List<Image>(db.Images.Take(8)),
                    Diagnoses = new List<Diagnose>(db.Diagnoses.Take(1)),
                    Medications = new List<Medication>(db.Medications.Take(1)),

                },
            };
            return reports;
        }

        public static List<Medication> GetMedications(HealthContext db)
        {
            Random rnd = new Random();
            List<Medication> medications = new List<Medication>()
            {
                new Medication
                {
                    MedicationId = "M0001",
                    Medicines = new List<Medicine>(db.Medicines.Take(4)),
                }
            };
            return medications;
        }

        public static List<Image> GetImages()
        {
            List<Image> images = new List<Image>()
            {
                new Image
                {
                    ImageId = "I0001",
                    ImageName = "CT Scan",
                    ImageUrl = "https://st2.depositphotos.com/2779653/6137/i/950/depositphotos_61373005-stock-photo-ct-brain-show-left-thalamic.jpg",
                },
                new Image
                {
                    ImageId = "I0002",
                    ImageName = "CT Scan",
                    ImageUrl = "https://st2.depositphotos.com/2779653/6137/i/950/depositphotos_61373013-stock-photo-ct-brain-show-ischemic-stroke.jpg",
                },
                new Image
                {
                    ImageId = "I0003",
                    ImageName = "CT Scan",
                    ImageUrl = "https://st2.depositphotos.com/2779653/7287/i/950/depositphotos_72876373-stock-photo-brain-injury-stroke-ct-scan.jpg",
                },
                new Image
                {
                    ImageId = "I0004",
                    ImageName = "CT Scan",
                    ImageUrl = "https://st2.depositphotos.com/2779653/6132/i/950/depositphotos_61326293-stock-photo-mri-brain-show-brain-tumor.jpg",
                },
                new Image
                {
                    ImageId = "I0005",
                    ImageName = "CT Scan",
                    ImageUrl = "https://st2.depositphotos.com/2779653/6159/i/950/depositphotos_61593669-stock-photo-mri-brain-brain-tumor-at.jpg",
                },
                new Image
                {
                    ImageId = "I0006",
                    ImageName = "MRI",
                    ImageUrl = "https://cdn.pixabay.com/photo/2015/05/24/21/47/mri-782459_960_720.jpg",
                },
                new Image
                {
                    ImageId = "I0007",
                    ImageName = "MRI",
                    ImageUrl = "https://cdn.pixabay.com/photo/2015/05/24/21/46/mri-782457_640.jpg",
                },
                new Image
                {
                    ImageId = "I0008",
                    ImageName = "CT Scan",
                    ImageUrl = "https://st2.depositphotos.com/2779653/6159/i/950/depositphotos_61593669-stock-photo-mri-brain-brain-tumor-at.jpg",
                },
            };
            return images;
        }

        public static List<Diagnose> GetDiagnoses()
        {
            List<Diagnose> diagnoses = new List<Diagnose>()
            {
                new Diagnose
                {
                    DiagnoseId = "D0001",
                    SelfDescription = "I had a headache three days ago, and my temperature increased up to 38.5 degrees yesterday " +
                    "when I had a test. I feel my hands and feet ached all over, and I found myself cannot go to work this morning.",
                    ClinicianDescription = "The sympton appeared on 8-8-2020, and the patient feel headache, weekness, hands and feet " +
                    "ached. Diagnosing that he is at the early stage of cold, and is now with a little fever.",
                    Suggestions = "1. Take vitamins and drink juice. 2. Take more water. 3. Have good rest at home.",
                },
            };
            return diagnoses;
        }

        public static List<Medicine> GetMedicines()
        {
            List<Medicine> medicines = new List<Medicine>()
            {
                new Medicine
                {
                    MedicineId = "Mdc0001",
                    MedicineName = "Theraflu",
                    MedicineUrl = "https://media.istockphoto.com/photos/theraflu-nighttime-severe-cold-and-cough-picture-id458647269",
                    TimesPerDay = "2",
                    PiecesPerTime = "1",
                    Directions = "Take orally",
                },
                new Medicine
                {
                    MedicineId = "Mdc0002",
                    MedicineName = "Paracetamol",
                    MedicineUrl = "https://media.istockphoto.com/photos/generic-paracetamol-isolated-on-white-picture-id157402355",
                    TimesPerDay = "1",
                    PiecesPerTime = "2",
                    Directions = "Take orally",
                },
                new Medicine
                {
                    MedicineId = "Mdc0003",
                    MedicineName = "Tylenol",
                    MedicineUrl = "https://media.istockphoto.com/photos/tylenol-extra-strength-for-adults-box-picture-id494180077",
                    TimesPerDay = "1",
                    PiecesPerTime = "2",
                    Directions = "Take orally",
                },
                new Medicine
                {
                    MedicineId = "Mdc0004",
                    MedicineName = "Gabapentin",
                    MedicineUrl = "https://media.istockphoto.com/photos/generic-gabapentin-pills-for-pain-relief-picture-id1223269251",
                    TimesPerDay = "3",
                    PiecesPerTime = "1",
                    Directions = "Take orally",
                },
            };
            return medicines;
        }


        
    }
}
