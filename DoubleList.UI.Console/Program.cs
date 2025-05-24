using DoubleList;

var list = new DoublyLinkedList<string>();
var opc = "0";

do
{
    opc = Menu();
    switch (opc)
    {
        case "1":
            Console.Write("Enter the data to add data: ");
            var dataToAdd = Console.ReadLine();
            if (dataToAdd != null)
            {
                list.InsertInOrder(dataToAdd);
            }
            break;
        case "2":
            Console.WriteLine(list.GetForward());
            break;
        case "3":
            Console.WriteLine(list.GetBackward());
            break;
        case "4":
            Console.Write("Enter the data to add data: ");
            list.ReverseList();
            break;
        case "5":
            Console.Write("Modas: ");
            Console.WriteLine(list.Moda());
            break;
        case "6":
            Console.WriteLine("Graphic");
            Console.WriteLine(list.Graphic());
            break;
        case "7":
            Console.Write("Enter the data to check if exists: ");
            var dataToCheck = Console.ReadLine();
            if (dataToCheck != null)
            {
                Console.WriteLine(list.Exists(dataToCheck));
            }
            break;
        case "8":
            Console.Write("Enter the data to remove: ");
            var remove = Console.ReadLine();
            if (remove != null)
            {
                list.Remove(remove);
                Console.WriteLine("Item removed.");
            }
            break;
        case "9":
            Console.Write("Enter the data to remove: ");
            var remove_all = Console.ReadLine();
            if (remove_all != null)
            {
                list.RemoveAllOcurrences(remove_all);
                Console.WriteLine("Item removed.");
            }
            break;
    }
}
while (opc != "0");

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show list forward");
    Console.WriteLine("3. Show list backward");
    Console.WriteLine("4. Order list backwards (reverse list)");
    Console.WriteLine("5. Modas");
    Console.WriteLine("6. Graphic the list");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Remove One Ocurrence");
    Console.WriteLine("9. Remove All Ocurrences");

    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? "0";
}