using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helpers;

internal static class DataHelper
{
    public static Guid DummyGuid(int n)
    {
        return n switch
        {
            1 => Guid.Parse("4e096c77-0774-4b80-8d0c-b86a17f3c512"),
            2 => Guid.Parse("3f5e96e8-d180-4e6b-b5d6-02a732d7374e"),
            3 => Guid.Parse("45650fbf-bba3-4016-a801-5cc90f09ec86"),
            4 => Guid.Parse("24172d0a-d5ef-41df-a837-3d03264116a0"),
            _ => Guid.Parse("b9f2ab8f-d3c1-49ef-a39a-c0b7c4bf38ad")
        };
    }

    public static User GetUser(int n)
    {
        return n switch
        {
            1 => new User("Jeff", "Winger", "Tango"),
            2 => new User("Abed", "Nadir", "Inspector"),
            3 => new User("Troy", "Barnes", "T-Bone"),
            4 => new User("Britta", "Perry", "The_Worst"),
            5 => new User("Annie", "Eddison", "Annie_Adderal"),
            6 => new User("Pierce", "Hawthorne", "Anastasia"),
            7 => new User("Shirley", "Bennet", "Big_Cheddar"),
            _ => new User("Ben", "Chang", "El_Tigre_Chino"),
        };
    }

    public static DateTime DummyDateTime(int n)
    {
        return n switch
        {
            1 => new DateTime(2023, 1, 5),
            2 => new DateTime(2023, 1, 4),
            3 => new DateTime(2023, 1, 3),
            4 => new DateTime(2023, 1, 2),
            _ => new DateTime(2023, 1, 1)
        };
    }
}
