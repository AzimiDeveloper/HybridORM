using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hama.Share.Models.Mock
{
    public static class  MockGenerator
    {
        public static DataTable GenerateLargeDataTable(int rows, int columns)
        {
            var table = new DataTable();

            // ساخت ستون‌ها
            for (int i = 0; i < columns; i++)
                table.Columns.Add($"Col{i}", typeof(string));

            var partitioner = Partitioner.Create(0, rows);
            var dataRows = new List<object[]>(rows);

            // تولید سریع دیتا به صورت موازی
            Parallel.ForEach(Partitioner.Create(0, rows), range =>
            {
                var localRows = new List<object[]>();
                var random = new Random();

                for (int i = range.Item1; i < range.Item2; i++)
                {
                    var row = new object[columns];
                    for (int j = 0; j < columns; j++)
                        row[j] = $"{Guid.NewGuid().ToString()}_{random.Next(1, 1000)}";
                    localRows.Add(row);
                }

                lock (table)
                {
                    foreach (var r in localRows)
                        table.Rows.Add(r);
                }
            });

            return table;
        }

        // ساخت سریع لیست جنریک با Parallel
        public static List<Dictionary<string, string>> GenerateLargeList(int rows, int columns)
        {
            var list = new List<Dictionary<string, string>>(rows);

            Parallel.For(0, rows, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                var dict = new Dictionary<string, string>(columns);
                var random = new Random();

                for (int j = 0; j < columns; j++)
                    dict[$"Col{j}"] = $"Val_{i}_{j}_{random.Next()}";

                lock (list)
                    list.Add(dict);
            });

            return list;
        }

        public static List<Person> GenerateMockPeople(int count)
        {
            var people = new Person[count];
            Parallel.For(0, count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
            {
                var random = new Random(Guid.NewGuid().GetHashCode());

                people[i] = new Person
                {
                    Id = i + 1,
                    FirstName = $"First{i}",
                    LastName = $"Last{i}",
                    Email = $"user{i}@example.com",
                    Address = $"{i} Main Street",
                    City = $"City_{i % 100}",
                    Country = $"Country_{i % 50}",
                    SecondaryEmail = $"secondary_{i}@example.com",
                    EmergencyContact = $"emergency_{i}@example.com",
                    DateOfBirth = DateTime.Now.AddYears(-random.Next(18, 70)).AddDays(-random.Next(0, 365)),
                    ZipCode = $"{random.Next(10000, 99999)}",
                    JobTitle = $"Job_{i % 300}",
                    Company = $"Company_{i % 100}",
                    Salary = random.Next(30000, 200000),
                    JoinDate = DateTime.Now.AddDays(-random.Next(0, 3650)),
                    Phone = $"+98-{random.Next(1000000, 9999999)}",
                    IsActive = i % 2 == 0
                };
            });

            return new List<Person>(people);
        }

        public static Task<List<HealthInsurancePolicy>> GenerateMockPolicies(int count)
        {
            return Task.Run(() =>
            {
                var policies = new List<HealthInsurancePolicy>(count);

                string[] firstNames = { "رضا", "زهرا", "علی", "سارا", "محمد", "مریم", "حسین", "فاطمه", "امیر", "نگار" };
                string[] lastNames = { "احمدی", "کریمی", "محمدی", "رضایی", "صادقی", "جعفری", "نوری", "کاظمی", "اکبری", "موسوی" };
                string[] companies = { "بیمه ایران", "بیمه آسیا", "بیمه دانا", "بیمه پاسارگاد", "بیمه البرز" };
                string[] policyTypes = { "عادی", "طلایی", "ویژه" };
                string[] genders = { "مرد", "زن" };
                string[] benefitsMale = { "دندانپزشکی", "بینایی‌سنجی", "ورزش", "چکاپ" };
                string[] benefitsFemale = { "ماموگرافی", "سلامت بانوان", "چکاپ", "بینایی‌سنجی" };
                string[] hospitals = Enumerable.Range(1, 50).Select(i => $"بیمارستان شماره {i}").ToArray();

                Parallel.For(0, count, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, i =>
                {
                    var random = new Random(Guid.NewGuid().GetHashCode());

                    var gender = genders[i % 2];
                    var firstName = firstNames[random.Next(firstNames.Length)];
                    var lastName = lastNames[random.Next(lastNames.Length)];
                    var fullName = $"{firstName} {lastName}";
                    var company = companies[random.Next(companies.Length)];
                    var type = policyTypes[i % 3];
                    var birthDate = DateTime.Now.AddYears(-random.Next(20, 60)).AddDays(random.Next(0, 365));
                    var startDate = DateTime.Now.AddDays(-random.Next(0, 180));
                    var endDate = startDate.AddYears(1);
                    var issueDate = startDate.AddDays(-random.Next(0, 10));

                    var policy = new HealthInsurancePolicy
                    {
                        PolicyId = i + 1,
                        InsuredPersonId = random.Next(100000, 999999),
                        FullName = fullName,
                        BirthDate = birthDate,
                        Gender = gender,
                        InsuranceCompany = company,
                        PolicyType = type,
                        StartDate = startDate,
                        EndDate = endDate,
                        PremiumAmount = Math.Round(random.Next(500000, 5000000) + random.NextDouble(), 2),
                        CoverageAmount = Math.Round(random.Next(10000000, 100000000) + random.NextDouble(), 2),
                        Deductible = Math.Round(random.Next(100000, 500000) + random.NextDouble(), 2),
                        IsActive = i % 6 != 0,
                        PolicyStatus = i % 6 == 0 ? "منقضی شده" : "فعال",
                        Beneficiary = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}",
                        HospitalNetwork = hospitals[random.Next(hospitals.Length)],
                        AdditionalBenefits = gender == "مرد"
                            ? $"{benefitsMale[random.Next(benefitsMale.Length)]}, {benefitsMale[random.Next(benefitsMale.Length)]}"
                            : $"{benefitsFemale[random.Next(benefitsFemale.Length)]}, {benefitsFemale[random.Next(benefitsFemale.Length)]}",
                        PolicyTerms = "این بیمه‌نامه طبق شرایط عمومی بیمه‌های درمان صادر شده است.",
                        IssueDate = issueDate,
                        AgentId = random.Next(1000, 9999)
                    };

                    lock (policies)
                        policies.Add(policy);
                });

                return policies;
            });
        }



    }


}
