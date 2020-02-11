using System;

namespace Spec.Test
{
    // https://docs.microsoft.com/dotnet/api/system.type.isassignablefrom
    // Room <- Kitchen
    //      <- Bedroom <- Guestroom
    //                 <- MasterBedroom
    class Room
    {
    }
    class Kitchen : Room
    {
    }
    class Bedroom : Room
    {
    }
    class Guestroom : Bedroom
    {
    }
    class MasterBedroom : Bedroom
    {
    }

    class Type
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Type Test");

            // Bedroom => Room
            // Room is assignable from Bedroom.
            var result = typeof(Room).IsAssignableFrom(typeof(Bedroom));
            Console.WriteLine("Room IsAssignableFrom Bedroom is " + result);

            Console.WriteLine("[E]Type Test");
        }
    }
}
