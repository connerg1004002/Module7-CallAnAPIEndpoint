using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

public class Program {
  static HttpClient client = new HttpClient();
  static void Main() {
    string? name1, name2, name3;

    Console.WriteLine("Enter three names");
    Console.WriteLine();

    //Get first name
    while (true) {
      Console.Write("Enter first name\n>>");
      name1 = Console.ReadLine();
      Console.WriteLine();
      if (name1 is not null)
        break;
    }

    //Get second name
    while (true) {
      Console.Write("Enter second name\n>>");
      name2 = Console.ReadLine();
      Console.WriteLine();
      if (name2 is not null)
        break;
    }

    //Get third name
    while (true) {
      Console.Write("Enter third name\n>>");
      name3 = Console.ReadLine();
      Console.WriteLine();
      if (name3 is not null)
        break;
    }

    //Get json string with response
    string jsonString = client.GetStringAsync($"http://api.agify.io/?name[]={name1}&name[]={name2}&name[]={name3}").GetAwaiter().GetResult();

    //Convert
    AgeData[]? data = JsonConvert.DeserializeObject<AgeData[]>(jsonString);

    //If data is there
    if (data is not null) {
      //Print info
      Console.WriteLine($"Name 1:{data[0].name} is apx {data[0].age} years old\n");
      Console.WriteLine($"Name 2:{data[1].name} is apx {data[1].age} years old\n");
      Console.WriteLine($"Name 3:{data[2].name} is apx {data[2].age} years old\n");
      Console.WriteLine();

      //Get oldest
      AgeData oldest = data[0];
      if (data[1].age > oldest.age)
        oldest = data[1];
      if (data[2].age > oldest.age)
        oldest = data[2];

      //Print who is oldest
      Console.WriteLine($"{oldest.name} is oldest");
    }
  }
}
