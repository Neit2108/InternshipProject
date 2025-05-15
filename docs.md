# Tài liệu cấu trúc dự án Ecommerce (Tài liệu này được tham khảo từ nhiều nguồn, cụ thể là nhiều con AI khác nhau)

## Tổng quan

Dự án Ecommerce được xây dựng trên nền tảng ASP.NET Core MVC với kiến trúc nhiều tầng (N-tier), giúp tách biệt rõ ràng trách nhiệm của từng thành phần và dễ dàng mở rộng, bảo trì.

## Cấu trúc Solution

Solution bao gồm 4 project chính:

1. **Ecommerce.Web**: Project ASP.NET Core MVC chứa giao diện người dùng và xử lý request
2. **Ecommerce.Core**: Class Library chứa logic nghiệp vụ cốt lõi
3. **Ecommerce.Infrastructure**: Class Library chứa tầng hạ tầng (database, dịch vụ bên ngoài)
4. **Ecommerce.Shared**: Class Library chứa mã nguồn dùng chung

## Chi tiết từng thành phần

### Ecommerce.Web

#### Controllers/
Chứa các controller xử lý HTTP requests và trả về các responses:

- **HomeController.cs**: Xử lý trang chủ và các trang thông tin chung
- **ProductController.cs**: Xử lý hiển thị, tìm kiếm, lọc sản phẩm
- **CategoryController.cs**: Quản lý danh mục sản phẩm
- **CartController.cs**: Xử lý thêm, sửa, xóa sản phẩm trong giỏ hàng
- **CheckoutController.cs**: Xử lý quy trình thanh toán, đặt hàng
- **OrderController.cs**: Quản lý đơn hàng của người dùng
- **AccountController.cs**: Xử lý đăng nhập, đăng ký, quản lý thông tin tài khoản
- **AdminController.cs**: Điểm vào cho phần quản trị

#### Views/
Chứa các file giao diện người dùng:

- **Shared/**: Các view được sử dụng chung
  - **_Layout.cshtml**: Template chung cho toàn bộ website
  - **_LoginPartial.cshtml**: Phần đăng nhập/đăng ký
  - **_ValidationScriptsPartial.cshtml**: Script validation form
  - **Error.cshtml**: Trang lỗi
  - **_ProductCard.cshtml**: Template hiển thị sản phẩm
  - **_Pagination.cshtml**: Phân trang

- **Home/**: Các view của HomeController
  - **Index.cshtml**: Trang chủ
  - **Privacy.cshtml**: Trang chính sách riêng tư

- **Product/**: Các view của ProductController
  - **Index.cshtml**: Trang danh sách sản phẩm
  - **Details.cshtml**: Trang chi tiết sản phẩm
  - **Search.cshtml**: Trang kết quả tìm kiếm

- **Cart/**: Các view của CartController
  - **Index.cshtml**: Trang giỏ hàng
  - **Summary.cshtml**: Hiển thị tóm tắt giỏ hàng

- **Checkout/**: Các view của CheckoutController
  - **Index.cshtml**: Trang nhập thông tin đặt hàng
  - **Payment.cshtml**: Trang thanh toán
  - **Confirmation.cshtml**: Trang xác nhận đơn hàng

- **_ViewImports.cshtml**: Khai báo namespace và tag helper

#### Models/
Chứa các ViewModel để hiển thị dữ liệu lên view:

- **ErrorViewModel.cs**: Model cho trang lỗi
- **ProductViewModel.cs**: Model hiển thị sản phẩm
- **CategoryViewModel.cs**: Model hiển thị danh mục
- **CartViewModel.cs**: Model hiển thị giỏ hàng
- **CheckoutViewModel.cs**: Model xử lý thanh toán
- **PaginationViewModel.cs**: Model hỗ trợ phân trang

#### ViewComponents/
Các thành phần UI tái sử dụng trong nhiều view:

- **ShoppingCartViewComponent.cs**: Hiển thị giỏ hàng mini
- **CategoryMenuViewComponent.cs**: Menu danh mục sản phẩm
- **FeaturedProductsViewComponent.cs**: Hiển thị sản phẩm nổi bật

#### wwwroot/
Chứa các tài nguyên tĩnh:

- **css/**: File CSS
  - **site.css**: CSS chung cho toàn trang
  - **product.css**: CSS cho trang sản phẩm

- **js/**: JavaScript
  - **site.js**: JavaScript chung
  - **cart.js**: Xử lý giỏ hàng
  - **checkout.js**: Xử lý thanh toán

- **lib/**: Thư viện third-party
  - **bootstrap/**: Framework Bootstrap
  - **jquery/**: Thư viện jQuery
  - **jquery-validation/**: Thư viện validate form

- **images/**: Hình ảnh
  - **products/**: Hình ảnh sản phẩm
  - **banners/**: Banner quảng cáo
  - **logo.png**: Logo website

#### Areas/
Phân vùng chức năng cho phần quản trị:

- **Admin/**: Phân vùng quản trị
  - **Controllers/**
    - **DashboardController.cs**: Bảng điều khiển
    - **ProductManagementController.cs**: Quản lý sản phẩm
    - **OrderManagementController.cs**: Quản lý đơn hàng
  
  - **Views/**
    - **Dashboard/Index.cshtml**: Giao diện bảng điều khiển
    - **ProductManagement/**: Giao diện quản lý sản phẩm
    - **_ViewImports.cshtml**: Khai báo namespace cho area
  
  - **Models/**
    - **DashboardViewModel.cs**: Model cho bảng điều khiển
    - **ProductManagementViewModel.cs**: Model quản lý sản phẩm

#### Filters/
Chứa các Action Filter:

- **AdminAuthorizationFilter.cs**: Kiểm tra quyền quản trị
- **ShoppingCartFilter.cs**: Filter cho giỏ hàng

#### Extensions/
Extension methods dành riêng cho Web project:

- **ServiceExtensions.cs**: Extensions cho đăng ký dịch vụ
- **SessionExtensions.cs**: Extensions cho phiên làm việc

#### Middlewares/
Middleware xử lý request/response:

- **RequestLoggingMiddleware.cs**: Ghi log request

#### Services/
Các dịch vụ cụ thể cho Web project:

- **CartSessionService.cs**: Dịch vụ lưu giỏ hàng trong session
- **ImageService.cs**: Xử lý hình ảnh
- **PaymentGatewayService.cs**: Tích hợp cổng thanh toán

#### TagHelpers/
Custom Tag Helper:

- **PriceTagHelper.cs**: Hiển thị giá sản phẩm theo format
- **ActiveMenuTagHelper.cs**: Đánh dấu menu đang active

#### Các file config
- **appsettings.json**: Cấu hình chính
- **appsettings.Development.json**: Cấu hình môi trường phát triển
- **Program.cs**: Điểm khởi chạy ứng dụng
- **Startup.cs**: Cấu hình dịch vụ và pipeline

### Ecommerce.Core

#### Entities/
Chứa các đối tượng domain:

- **BaseEntity.cs**: Lớp cơ sở cho entity
- **Product.cs**: Thông tin sản phẩm
- **Category.cs**: Danh mục sản phẩm
- **Order.cs**: Thông tin đơn hàng
- **OrderItem.cs**: Chi tiết đơn hàng
- **Customer.cs**: Thông tin khách hàng
- **Address.cs**: Địa chỉ giao hàng
- **Payment.cs**: Thông tin thanh toán
- **Discount.cs**: Thông tin giảm giá, khuyến mãi

#### Interfaces/
Định nghĩa các interface:

- **IProductService.cs**: Interface dịch vụ sản phẩm
- **IOrderService.cs**: Interface dịch vụ đơn hàng
- **IProductRepository.cs**: Interface repository sản phẩm
- **ICategoryRepository.cs**: Interface repository danh mục
- **IOrderRepository.cs**: Interface repository đơn hàng
- **IUnitOfWork.cs**: Interface Unit of Work pattern

#### Enums/
Định nghĩa các giá trị enum:

- **OrderStatus.cs**: Trạng thái đơn hàng (Đang xử lý, Đã giao...)
- **PaymentMethod.cs**: Phương thức thanh toán
- **ProductStatus.cs**: Trạng thái sản phẩm

#### Exceptions/
Định nghĩa các ngoại lệ:

- **ProductNotFoundException.cs**: Không tìm thấy sản phẩm
- **PaymentFailedException.cs**: Lỗi thanh toán

#### Services/
Triển khai các dịch vụ nghiệp vụ:

- **ProductService.cs**: Dịch vụ xử lý sản phẩm
- **OrderService.cs**: Dịch vụ xử lý đơn hàng
- **DiscountService.cs**: Dịch vụ tính giảm giá
- **InventoryService.cs**: Dịch vụ quản lý tồn kho

#### DTOs/
Data Transfer Objects:

- **ProductDto.cs**: DTO cho sản phẩm
- **CategoryDto.cs**: DTO cho danh mục
- **OrderDto.cs**: DTO cho đơn hàng
- **CartItemDto.cs**: DTO cho item trong giỏ hàng
- **CheckoutRequestDto.cs**: DTO cho yêu cầu thanh toán

### Ecommerce.Infrastructure

#### Data/
Xử lý dữ liệu:

- **Contexts/**
  - **EcommerceDbContext.cs**: Ngữ cảnh database EF Core

- **Repositories/**
  - **RepositoryBase.cs**: Repository cơ sở
  - **ProductRepository.cs**: Repository sản phẩm
  - **CategoryRepository.cs**: Repository danh mục
  - **OrderRepository.cs**: Repository đơn hàng
  - **UnitOfWork.cs**: Triển khai Unit of Work pattern

- **Configurations/**
  - **ProductConfiguration.cs**: Cấu hình entity sản phẩm
  - **CategoryConfiguration.cs**: Cấu hình entity danh mục
  - **OrderConfiguration.cs**: Cấu hình entity đơn hàng

- **Migrations/**
  - **20250101000000_InitialCreate.cs**: Migration khởi tạo
  - **20250110000000_AddProductRatings.cs**: Migration thêm đánh giá sản phẩm

#### ExternalServices/
Tích hợp dịch vụ bên ngoài:

- **PaymentGateway/**
  - **PaymentGatewayService.cs**: Dịch vụ tích hợp cổng thanh toán
  - **PaymentGatewayOptions.cs**: Tùy chọn cấu hình

- **EmailService/**
  - **EmailService.cs**: Dịch vụ gửi email
  - **EmailTemplates.cs**: Mẫu email

- **ImageStorage/**
  - **CloudImageService.cs**: Dịch vụ lưu trữ hình ảnh trên cloud

#### Logging/
Ghi log:

- **DatabaseLogger.cs**: Logger ghi vào database

#### Identity/
Quản lý người dùng:

- **ApplicationUser.cs**: Mô hình người dùng
- **ApplicationRole.cs**: Mô hình vai trò người dùng
- **IdentityService.cs**: Dịch vụ xác thực

#### DependencyInjection.cs
Đăng ký các dịch vụ trong dependency injection container

### Ecommerce.Shared

#### Constants/
Các hằng số dùng chung:

- **ProductConstants.cs**: Hằng số liên quan sản phẩm
- **OrderConstants.cs**: Hằng số liên quan đơn hàng
- **SystemConstants.cs**: Hằng số hệ thống

#### Helpers/
Các hàm tiện ích:

- **StringHelper.cs**: Xử lý chuỗi
- **FileHelper.cs**: Xử lý file
- **DateTimeHelper.cs**: Xử lý ngày tháng

#### Extensions/
Extension methods:

- **StringExtensions.cs**: Mở rộng cho String
- **EnumExtensions.cs**: Mở rộng cho Enum
- **QueryableExtensions.cs**: Mở rộng cho IQueryable (phân trang, sắp xếp...)

### Tests

#### Ecommerce.UnitTests/
Kiểm thử đơn vị:

- **Services/**
  - **ProductServiceTests.cs**: Kiểm thử dịch vụ sản phẩm
  - **OrderServiceTests.cs**: Kiểm thử dịch vụ đơn hàng

- **Helpers/**
  - **TestDataHelper.cs**: Dữ liệu mẫu cho kiểm thử

#### Ecommerce.IntegrationTests/
Kiểm thử tích hợp:

- **Repositories/**
  - **ProductRepositoryTests.cs**: Kiểm thử repository sản phẩm

- **Api/**
  - **ProductControllerTests.cs**: Kiểm thử API sản phẩm

#### Ecommerce.FunctionalTests/
Kiểm thử chức năng:

- **Pages/**
  - **HomePageTests.cs**: Kiểm thử trang chủ
  - **CheckoutPageTests.cs**: Kiểm thử quy trình thanh toán

- **TestServerFixture.cs**: Cấu hình server kiểm thử

### Tools

#### SeedData/
Dữ liệu khởi tạo:

- **products.json**: Dữ liệu sản phẩm mẫu
- **SeedDataScript.cs**: Script tạo dữ liệu ban đầu

### Docs

- **architecture.md**: Mô tả kiến trúc
- **api-documentation.md**: Tài liệu API
- **deployment.md**: Hướng dẫn triển khai

### Root files

- **.gitignore**: Cấu hình file bỏ qua cho Git
- **.editorconfig**: Cấu hình editor
- **global.json**: Cấu hình phiên bản .NET SDK
- **README.md**: Thông tin tổng quan dự án
- **Ecommerce.sln**: File solution Visual Studio

## Luồng dữ liệu

1. HTTP Request → Controller → Service → Repository → Database
2. Database → Repository → Service → ViewModel → View → HTTP Response

## Nguyên tắc thiết kế

1. **Single Responsibility Principle**: Mỗi class chỉ có một trách nhiệm duy nhất
2. **Dependency Inversion**: Các module cấp cao không phụ thuộc vào module cấp thấp
3. **Repository Pattern**: Tách biệt logic truy cập dữ liệu
4. **Unit of Work**: Đảm bảo tính nhất quán trong các transaction

## Khả năng mở rộng

Cấu trúc dự án cho phép dễ dàng:
- Thêm tính năng mới (chỉ cần thêm controller và service tương ứng)
- Thay đổi công nghệ lưu trữ (chỉ cần thực hiện lại các repository)
- Thay đổi UI (chỉ cần thay đổi view, giữ nguyên controller và service)

YourBookstore/
│
├── src/                              # Mã nguồn chính của ứng dụng
│   ├── YourBookstore.Web/            # Dự án web MVC chính (Presentation Layer)
│   │   ├── Controllers/              # Các controller xử lý request
│   │   │   └── BooksController.cs
│   │   │
│   │   ├── Views/                    # Giao diện người dùng
│   │   │   ├── Shared/               # Các view dùng chung
│   │   │   │   └── _Layout.cshtml
│   │   │   ├── Books/                # View của BooksController
│   │   │   │   ├── Index.cshtml
│   │   │   │   └── Details.cshtml
│   │   │   └── _ViewImports.cshtml
│   │   │
│   │   ├── Models/                   # View Models
│   │   │   └── BookViewModel.cs
│   │   │
│   │   ├── Services/                 # Các service phục vụ controller
│   │   │   └── BookViewService.cs
│   │   │
│   │   ├── wwwroot/                  # Tài nguyên tĩnh (CSS, JS, images...)
│   │   │   ├── css/
│   │   │   │   └── site.css
│   │   │   ├── js/
│   │   │   │   └── site.js
│   │   │   └── images/
│   │   │       └── logo.png
│   │   │
│   │   ├── appsettings.json          # Cấu hình ứng dụng
│   │   ├── appsettings.Development.json
│   │   ├── Program.cs                # Điểm khởi chạy ứng dụng
│   │   └── Startup.cs                # Cấu hình dịch vụ và pipeline
│   │
│   ├── YourBookstore.Core/           # Logic nghiệp vụ cốt lõi (Business Logic Layer)
│   │   ├── Entities/                 # Các entity (đối tượng nghiệp vụ)
│   │   │   └── Book.cs
│   │   │
│   │   ├── Interfaces/               # Các interface
│   │   │   ├── IBookRepository.cs
│   │   │   └── IBookService.cs
│   │   │
│   │   ├── DTOs/                     # Data Transfer Objects
│   │   │   └── BookDTO.cs
│   │   │
│   │   ├── Services/                 # Các dịch vụ nghiệp vụ
│   │   │   └── BookService.cs
│   │   │
│   │   └── Exceptions/               # Custom exceptions
│   │       └── BookNotFoundException.cs
│   │
│   ├── YourBookstore.Infrastructure/ # Tầng hạ tầng (Data Access Layer)
│   │   ├── Data/                     # Tương tác với database
│   │   │   ├── Contexts/             # DbContext
│   │   │   │   └── EcommerceDbContext.cs
│   │   │   ├── Migrations/           # Database migrations
│   │   │   └── Repositories/         # Các repository
│   │   │       └── BookRepository.cs
│   │   │
│   │   ├── Logging/                  # Cấu hình logging
│   │   │   └── Logger.cs
│   │   │
│   │   └── DependencyInjection.cs    # Đăng ký dependency
│   │
│   └── YourBookstore.Shared/         # Mã nguồn dùng chung cho các tầng (Shared Layer)
│       ├── Constants/                # Các hằng số
│       │   └── AppConstants.cs
│       │
│       ├── Helpers/                  # Các hàm tiện ích
│       │   └── FormatHelpers.cs
│       │
│       └── Extensions/               # Extension methods dùng chung
│           └── StringExtensions.cs
│
├── tests/                            # Mã nguồn kiểm thử
│   ├── YourBookstore.UnitTests/      # Unit tests
│   │   └── BookServiceTests.cs
│   │
│   ├── YourBookstore.IntegrationTests/ # Integration tests
│   │   └── BookRepositoryTests.cs
│   │
│   └── YourBookstore.FunctionalTests/ # Functional/E2E tests
│       └── BookFlowTests.cs
│
├── tools/                            # Công cụ hỗ trợ phát triển
│   └── GenerateTestData.cs
│
├── docs/                             # Tài liệu dự án
│   └── API_Documentation.md
│
├── .gitignore                        # Cấu hình Git ignore
├── .editorconfig                     # Cấu hình editor
├── global.json                       # Cấu hình .NET SDK version
├── README.md                         # Mô tả dự án
└── YourBookstore.sln                 # Solution file


- Entities -> Repositories -> Services(Core) -> DTOs -> Services(Web) -> ViewModel -> Controllers


## Quy trình viết Unit test

       ┌─────────────────────┐
       │ 1. Chọn phương thức │
       └─────────┬───────────┘
                 ↓
       ┌─────────────────────┐
       │ 2. Tạo Test Project │
       └─────────┬───────────┘
                 ↓
       ┌─────────────────────┐
       │ 3. Mock dependency  │◄────┐
       └─────────┬───────────┘     │
                 ↓                 │
       ┌─────────────────────┐     │
       │ 4. Viết test method │     │
       └─────────┬───────────┘     │
     (AAA: Arrange - Act - Assert) │
                 ↓                 │
       ┌─────────────────────┐     │
       │ 5. Kiểm thử case     │────┘
       │    đặc biệt / lỗi   │
       └─────────┬───────────┘
                 ↓
       ┌─────────────────────┐
       │ 6. Chạy & duy trì   │
       └─────────────────────┘
