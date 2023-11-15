using ConsoleApp64;
/*double Act(double x)
{
    return 1 / (1 + Math.Pow(Math.E, -x));
}
double h1=Act(0.45);
double h2=Act(0.78);
double o1 = Act(h1 * 1.5 - 2.3 * h2);
Console.WriteLine(  o1);
double fail = (1 - o1) * (1 - o1);
Console.WriteLine(fail);

//Enters enter1=new Enters(1.0 , 0.45 ,0,78);
Console.WriteLine(  );
Enters enter2=new Enters(0,0.5,0);
Enters enter1=new Enters(1,0.45,0.78);
Hiden hiden1 = new Hiden(enter1.OutW()+enter2.OutW(), 1.5);

Hiden hiden2 = new Hiden(enter1.OutW2(),-2.3);

OutPuts outPuts = new OutPuts(hiden1.OutIn()+hiden2.OutIn());
 outPuts.OutCW();
*/
NeyrolNetwork neyrolNetwork=new NeyrolNetwork(5,2,1,3);
//neyrolNetwork.Initialization();
//neyrolNetwork.Work();
Console.WriteLine(  );
//neyrolNetwork.Zero();
//neyrolNetwork.Work2();
double fail = 0;
List<double> answers = new List<double>();
//List<List<int>> ints = new List<List<int>>();
int[,] mas = new int[,] { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 1, 1 } };
int[] correctanswer = new int[] { 0, 1, 1, 0 };
for (int i = 0; i < 10; i++)
{

    for (int j = 0; j < mas.GetLength(0); j++)
    {
        NForms.Ideal = correctanswer[j];
        for (int x = 0; x < mas.GetLength(1); x++)
        {
            neyrolNetwork.layers[0].neyrons[x].Input = mas[j, x];
           
            
        }
        double t = neyrolNetwork.Work2();
     //   answers.Add(t);
        neyrolNetwork.Learn();
       
        if (i % 1 == 0) {
            Console.WriteLine(mas[j, 0] + " " + mas[j, 1] + " " + " для этого сета");
            Console.WriteLine(t + "-ответ");
          
            Console.WriteLine("---------------");
        }
        
        /*   foreach (var y in answers)
           {
               fail += (NForms.Ideal - y) * (NForms.Ideal - y);
           }
           fail /= answers.Count;
           if (i % 1 == 0) Console.WriteLine(fail + " ошибка");
           fail = 0;
        */

        neyrolNetwork.Zero();

    }
   
}