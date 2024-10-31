using SolidPrincipleDemo.Dip;
using SolidPrincipleDemo.Isp;
using SolidPrincipleDemo.Lsp;
using SolidPrincipleDemo.Ocp;
using SolidPrincipleDemo.Srp;

#region SRP
//--------------------------- Chưa áp dụng quy tắc SRP ------------------------------//
// Mọi hàm, chức năng đều viết chung trong GarageStation
GarageStation notCrp = new GarageStation();
Vehicle vehicle = new Vehicle()
{
    NameService = "Dich vu rửa xe"
};
notCrp.DoOpenGate();
notCrp.PerformService(vehicle);
notCrp.DoCloseGate();


Console.WriteLine("Áp dụng quy tắc SRP");
//--------------------------- Áp dụng quy tắc SRP (Nguyên tắc mỗi lớp, module chỉ nên có 1 trách nhiêm duy nhất)------------------------------//
//Áp dụng SRP để chia các nhiệm vụ trong 1 class ra riêng.
//GarageStationSrp chỉ làm DoService,
//Các giờ mở cửa đóng cửa thì nên dùng ở class riêng là GarageStationUtility
//Khi cần lấy giờ mở đóng cửa thì gọi hàm GarageStationUtility
IGarageUtility utility = new GarageStationUtility();
GarageStationSrp crp = new GarageStationSrp(utility);

crp.OpenForService();
crp.DoService();
crp.CloseGarage();

Console.WriteLine("\n");
#endregion


#region OCP
//--------------------------- Chưa áp dụng quy tắc OCP ------------------------------//
// Code không kế thừa khi cần chỉnh 1 cái gì đó phải tới hàm CalcInterest, các hàm khác bên trong có thể bị ảnh hưởng
Account notOcp = new Account();
notOcp.Balance = 10;
var regular1 = notOcp.CalcInterest("Regular");
Console.WriteLine("Insert Regular", regular1.ToString());

//--------------------------- Áp dụng quy tắc OCP (Nguyên tắc kế thừa để mở rộng mà ko cần sửa code cũ)------------------------------------------//
//Viết code theo nguyên tắc kế thừa
//Nếu 1 hàm có 1 chức năng nhưng chức năng xủ lý theo các đầu vào khác nhau, thì nên có 1 hơp đồng chung
//các class khác nên kế thừa theo nguyên tác đó, và xử lý logic khác nhau tùy vào dữ liệu đầu vào
//khi cần chỉnh sửa chỉ chỉnh sửa trong class đó
RegularSavingAccount ocp = new RegularSavingAccount();
ocp.Balance = 10;
var regular2 = ocp.CalcInterest();
Console.WriteLine("Insert Regular", regular2.ToString());
//Ỡ đây việc tính toán RegularSavingAccount đã được viết tách riêng ra các hàm SalarySavingAccount, CorporateAccount
//Nhưng đều có nhiêm vu là Calc Interest

Console.WriteLine("\n");
#endregion



#region LSP
//--------------------------- Chưa áp dụng quy tắc LSP ------------------------------//
// khi chưa áp dụng nguyên tắc này lớp Circle đã cho ra kết qua sai so với lớp cha Triangle
// kết quả mong muốn là trả ra "Triangle"
Triangle triangle = new Circle();
Console.WriteLine(triangle.GetShape());


//--------------------------- Áp dụng quy tắc LSP (Nguyên tắc kế thừa quan hệ giữa lớp cha và con) ------------------------------------------//
// Áp dụng quy tắc này lớp cha để là GetShape
// 2 lớp con kế thừa đều tuân thủ nguyên tắc: Trả ra 1 hình dạng nào đó và trả ra kết quả đúng đắn
ShapeLsp shape = new CircleLsp();
Console.WriteLine(shape.GetShape());
shape = new TriangleLsp();
Console.WriteLine(shape.GetShape());

Console.WriteLine("\n");
#endregion

#region ISP

//--------------------------- Chưa áp dụng quy tắc ISP ------------------------------//
//chỉ có OnlineOrder mới dùng phương thức thanh toán CCProcess
OfflineOrder order = new OfflineOrder();
// trong OfflineOrder kế thừa nhưng ko dùng phương thức CCProcess
//order.CCProcess();


//--------------------------- Áp dụng quy tắc ISP (Các lớp phụ thuộc chỉ nên sử dụng các giao diện mà họ cần) ------------------------------------------//
//Trong lớp này đã sử dụng nguyên tắc Isp, khi đó phương thức thanh toán OfflineOrder không cần phải triển khai phương thức thanh toán CCProcess
OfflineOrderIsp order2 = new OfflineOrderIsp();
//order2.CCProcessIsp(); không có phương thức thanh toán 
order2.AddToCartIsp();  // chỉ có phương thức  add to cart
Console.WriteLine("\n");

#endregion


#region DIP
//--------------------------- Áp dụng quy tắc DIP ------------------------------------------//
//Hàm AutomobileController đã sử dụng quy tác DIP tránh phụ thuộc trực tiếp vào lớp Jeep hoặc lớp SUV
//AutomobileController ko có trách nhiệm tạo và quản lý các phụ thuộc của chúng
//Lớp AutomobileController vẫn phụ thuộc vào lớp Jeep hoặc SUV nhưng chúng ta làm giảm sự phụ thuôc đó bằng cách dùng Dependency Injection

IAutomobile automobile = new Jeep();
//IAutomobile automobile = new SUV();
AutomobileController automobileController = new AutomobileController(automobile);
automobileController.Ignition();
automobileController.Stop();


//IAutomobile automobile = new Jeep();
IAutomobile automobile2 = new SUV();
AutomobileController automobileController2 = new AutomobileController(automobile2);
automobileController2.Ignition();
automobileController2.Stop();

Console.Read();
#endregion