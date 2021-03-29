using MarriageAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Data
{
    public class DbInitializer
    {
        private static Random randObj = new Random(1);
        public static void Initialize(MarriageAgencyContext db)
        {
            db.Database.EnsureCreated();

            int employeeCount = 50;
            int clientCount = 50;
            int serviceCount = 100;

            ZodiacSignGenerate(db);
            RelationshipGenerator(db);
            NationalityGenerate(db);
            EmployeesGenerate(db, employeeCount);
            CustomersGenerate(db, clientCount);
            ServicesGenerate(db, serviceCount);
        }

        public static void ZodiacSignGenerate(MarriageAgencyContext db)
        {
            if (db.ZodiacSigns.Any())
            {
                return;
            }

            db.ZodiacSigns.AddRange(new ZodiacSign[] 
            { 
                new ZodiacSign()
                {
                    Name = "Aries",
                    Description = "Aries loves to be number one," +
                    " so it’s no surprise that these audacious rams are the first " +
                    "sign of the zodiac."
                },
                new ZodiacSign()
                {
                    Name = "Taurus",
                    Description = "Taurus is an earth sign represented by the bull." +
                    " Like their celestial spirit animal, Taureans enjoy relaxing in" +
                    " serene, bucolic environments surrounded by soft sounds, soothing" +
                    " aromas, and succulent flavorsc."
                },
                new ZodiacSign()
                {
                    Name = "Gemini",
                    Description = "Have you ever been so busy that you wished you could " +
                    "clone yourself just to get everything done? That’s the Gemini experience " +
                    "in a nutshell."
                }, 
                new ZodiacSign()
                {
                    Name = "Cancer",
                    Description = "Cancer is a cardinal water sign. Represented by the crab, this crustacean seamlessly weaves between the sea and shore representing Cancer’s ability to exist in both emotional and material realms."
                },
                new ZodiacSign()
                {
                    Name = "Leo",
                    Description = "Roll out the red carpet because Leo has arrived. Leo is represented by the lion and these spirited fire signs are the kings and queens of the celestial jungle."
                },
                new ZodiacSign()
                {
                    Name = "Virgo",
                    Description = "Virgo is an earth sign historically represented by the goddess of wheat and agriculture, an association that speaks to Virgo’s deep-rooted presence in the material world."
                },
                new ZodiacSign()
                {
                    Name = "Libra",
                    Description = "Libra is an air sign represented by the scales (interestingly, the only inanimate object of the zodiac), an association that reflects Libra's fixation on balance and harmony."
                },
                new ZodiacSign()
                {
                    Name = "Scorpio",
                    Description = "Scorpio is one of the most misunderstood signs of the zodiac. Because of its incredible passion and power, Scorpio is often mistaken for a fire sign. "
                },
                new ZodiacSign()
                {
                    Name = "Sagittarius",
                    Description = "Represented by the archer, Sagittarians are always on a quest for knowledge."
                },
                new ZodiacSign()
                {
                    Name = "Capricorn",
                    Description = "The last earth sign of the zodiac, Capricorn is represented by the sea goat, a mythological creature with the body of a goat and the tail of a fish."
                },
                new ZodiacSign()
                {
                    Name = "Aquarius",
                    Description = "Despite the “aqua” in its name, Aquarius is actually the last air sign of the zodiac. "
                },
                new ZodiacSign()
                {
                    Name = "Pisces",
                    Description = "Pisces, a water sign, is the last constellation of the zodiac. It's symbolized by two fish swimming in opposite directions, representing the constant division of Pisces' attention between fantasy and reality. "
                },
            });
            db.SaveChanges();
        }

        public static void RelationshipGenerator(MarriageAgencyContext db)
        {
            if (db.Relationships.Any())
            {
                return;
            }

            db.Relationships.AddRange(new Relationship[]
            {
                new Relationship()
                {
                    Name = "Codependent Relationships",
                    Desctiption = "A codependent relationship means that one (or more likely both) of you are reliant on the other to function."
                },
                new Relationship()
                {
                    Name = "Independent Relationships",
                    Desctiption = "The flip side of the codependent relationship is the independent relationship."
                },
                new Relationship()
                {
                    Name = "Dominant/Submissive Relationships",
                    Desctiption = "The unhealthy version of our first two entries takes the negative sides of both to an extreme. One person in the relationship exerts total control over the other."
                },
                new Relationship()
                {
                    Name = "Open Relationships",
                    Desctiption = "An open relationship is another version of an independent relationship."
                },
                new Relationship()
                {
                    Name = "Long Distance Relationships ",
                    Desctiption = "This one stands out as unique on the list."
                },
                new Relationship()
                {
                    Name = "Toxic Relationships ",
                    Desctiption = "The complete opposite of a healthy relationship is a toxic one."
                }
            });
            db.SaveChanges();
        }

        public static void NationalityGenerate(MarriageAgencyContext db)
        {
            if (db.Nationalities.Any())
            {
                return;
            }
            db.Nationalities.AddRange(new Nationality[]
            {
                new Nationality()
                {
                    Name = "Ukrainians",
                    Note = "Love lard"
                },
                new Nationality()
                {
                    Name = "Belarusians",
                    Note = "Love potatoes"
                },
                new Nationality()
                {
                    Name = "Moldovans",
                    Note = "Roman-speaking people in Southeast Europe."
                },
                new Nationality()
                {
                    Name = "Jews",
                    Note = "People of semitic origin."
                },
                new Nationality()
                {
                    Name = "Gypsies",
                    Note = "One of the largest ethnic minorities in Europe"
                },
            });
            db.SaveChanges();
        }

        public static void EmployeesGenerate(MarriageAgencyContext db, int count)
        {
            if (db.Customers.Any())
            {
                return;
            }
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string[] fullNamesVoc = { "Zhmailik A.V.", "Setko A.I.", "Semenov D.S.", "Davidchik A.E.", "Piskun E.A.",
                                  "Drakula V.A.", "Yastrebov A.A.", "Steponenko Y.A.", "Basharimov Y.I.", "Karkozov V.V.", "Lipsky D.Y." };

            string[] addressVoc = {"Mozyr, per.Zaslonova, ", "Gomel, st.Gastelo, ", "Minsk, st.Poleskay, ",
                "Grodno, pr.Rechetski, ", "Vitebsk, st, International, ",
                                    "Brest, pr.October, ", "Minsk, st.Basseinaya, ", "Mozyr, boulevard Youth, " };

            string[] sexVoc = { "Male", "Female" };

            for (int i = 0; i < count; i++)
            {
                var fullName = fullNamesVoc[randObj.Next(fullNamesVoc.GetLength(0))] + randObj.Next(count);
                var age = randObj.Next(18, 60);
                var sex = sexVoc[randObj.Next(sexVoc.GetLength(0))];
                var address = addressVoc[randObj.Next(addressVoc.GetLength(0))] + randObj.Next(count);
                var phoneNumber = "+375 (29) " + randObj.Next(100, 999) + "-" + randObj.Next(10, 99) +
                              "-" + randObj.Next(10, 99);
                var passportData = new string(Enumerable.Repeat(chars, 2)
                                .Select(s => s[randObj.Next(s.Length)]).ToArray()).ToUpper() + randObj.Next(100000, 999999);
                db.Employees.Add(new Employee()
                {
                    FullName = fullName,
                    Age = age,
                    Sex = sex,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    PassportData = passportData
                });
            }
            db.SaveChanges();
        }

        public static void CustomersGenerate(MarriageAgencyContext db, int count)
        {
            if (db.Customers.Any())
            {
                return;
            }

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz  ";
            string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


            var zodiacSignCount = db.ZodiacSigns.Count();
            var relationshipCount = db.Relationships.Count();
            var nationalityCount = db.Nationalities.Count();

            string[] fullNamesVoc =
            {
                "Lipsky D.Y.", "Stolny S.D.", "Semenov D.S.", "Deker M.A.",
                "Ropot I.V.", "Butkovski Y.V.",
                "Stepanenko Y.V.", "Moiseikov R.A.", "Rogolevich N.V.", "Gerosimenko M.A.",
                "Galetskiy A.A.", "Zankevich K.A."
            };

            string[] addressVoc = {"Mozyr, per.Zaslonova, ", "Gomel, st.Gastelo, ", "Minsk, st.Poleskay, ",
                "Grodno, pr.Rechetski, ", "Vitebsk, st, International, ",
                                    "Brest, pr.October, ", "Minsk, st.Basseinaya, ", "Mozyr, boulevard Youth, " };

            string[] sexVoc = { "Male", "Female" };

            string[] maritalStatusVoc = { "Married", "Single" };

            string[] badHabitsVoc = { "Smoking", "Binge" };

            for (int i = 0; i < count; i++)
            {
                var fullName = fullNamesVoc[randObj.Next(fullNamesVoc.GetLength(0))] + randObj.Next(count);
                var sex = sexVoc[randObj.Next(sexVoc.GetLength(0))];
                var birthdayDate = DateTime.Now.AddDays(-randObj.Next(5000));
                var age = (DateTime.Now - birthdayDate).Days;
                var height = randObj.Next(160, 210);
                var weight = randObj.Next(50, 120);
                var childrenCount = randObj.Next(3);
                var martialStatus = maritalStatusVoc[randObj.Next(maritalStatusVoc.GetLength(0))];
                var badHabits = badHabitsVoc[randObj.Next(badHabitsVoc.GetLength(0))];
                var hobby = GetRandStr(chars, 15);
                var description = GetRandStr(chars, 25);
                var zodicaSignId = randObj.Next(1, zodiacSignCount + 1);
                var relationshipId = randObj.Next(1, relationshipCount + 1);
                var nationalityId = randObj.Next(1, nationalityCount + 1);
                var address = addressVoc[randObj.Next(addressVoc.GetLength(0))] + randObj.Next(count);
                var phoneNumber = "+375 (29) " + randObj.Next(100, 999) + "-" + randObj.Next(10, 99) +
                              "-" + randObj.Next(10, 99);
                var passportData = new string(Enumerable.Repeat(upperChars, 2)
                                .Select(s => s[randObj.Next(s.Length)]).ToArray()).ToUpper() + randObj.Next(100000, 999999);

                db.Customers.Add(new Customer()
                {
                    FullName = fullName,
                    Sex = sex,
                    BirthdayDate = birthdayDate,
                    Age = age,
                    Height = height,
                    Weight = weight,
                    ChildrenCount = childrenCount,
                    MaritalStatus = martialStatus,
                    BadHadits = badHabits,
                    Hobby = hobby,
                    Description = description,
                    ZodiacSignId = zodicaSignId,
                    RelationshipId = relationshipId,
                    NationalityId = nationalityId,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    PassportData = passportData
                });
            }
            db.SaveChanges();
        }

        public static void ServicesGenerate(MarriageAgencyContext db, int count)
        {
            if (db.Services.Any())
            {
                return;
            }

            var customersCount = db.Customers.Count();
            var employeesCount = db.Employees.Count();

            for (int i = 0; i < count; i++)
            {
                var date = DateTime.Now.AddDays(-randObj.Next(500));
                var price = randObj.Next(1, 250);
                var customerId = randObj.Next(1, customersCount + 1);
                var employeeId = randObj.Next(1, employeesCount + 1);

                db.Services.Add(new Service()
                {
                    Date = date,
                    Price = price,
                    CustomerId = customerId,
                    EmployeeId = employeeId
                });
            }
            db.SaveChanges();
        }

        private static string GetRandStr(string chars, int maxChar)
        {
            return new string(Enumerable.Repeat(chars, maxChar)
                                .Select(s => s[randObj.Next(s.Length)]).ToArray());
        }
    }
}
