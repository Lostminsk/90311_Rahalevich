using System;
using System.Collections.Generic;
using System.Text;
using _90311_Rahalevich.DAL.Data;
using _90311_Rahalevich.DAL.Entities;

namespace _90311_Rahalevich.Tests
{
    public class TestData
    {
        public static void FillContext(ApplicationDbContext context)
        {
            context.InsulinGroups.Add(new InsulinGroup
            { GroupName = "fake group" });
            context.AddRange(new List<Insulin>
            {
                new Insulin{ InsulinId=1, InsulinGroupId=1},
                new Insulin{ InsulinId=2, InsulinGroupId=1},
                new Insulin{ InsulinId=3, InsulinGroupId=2},
                new Insulin{ InsulinId=4, InsulinGroupId=2},
                new Insulin{ InsulinId=5, InsulinGroupId=3}
           });
            context.SaveChanges();
        }
        public static IEnumerable<object[]> Params()
        {
            // 1-я страница, кол. объектов 3, id первого объекта 1
            yield return new object[] { 1, 3, 1 };
            // 2-я страница, кол. объектов 2, id первого объекта 4
            yield return new object[] { 2, 2, 4 };
        }

    }
}
