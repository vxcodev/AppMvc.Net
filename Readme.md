## Controller
- Là 1 lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong Controller là 1 phương thức public (Không được là phương thức tĩnh - static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào Controller qua hàm khởi tạo
## View
- Là file .cshtml
- View của Action lưu tại: /Views/ControllerName/ActionName.cshtml
- Thêm thư mục lưu trữ View:
```
    services.Configure<RazorViewEngineOptions>(options=>{
        // {0} => Action Name
        // {1} => Controller Name 
        // {2} => Area Name
        options.ViewLocationFormats.Add("/MyView/{1}/{0}"+RazorViewEngine.ViewExtension);
    });
```
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData