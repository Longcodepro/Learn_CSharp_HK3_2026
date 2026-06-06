using DapperApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký Repository của bạn vào hệ thống
builder.Services.AddScoped<IStudentRepository, StudentRepository>(); 
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddControllers();

// ĐĂNG KÝ SWAGGER: Cấu hình để sinh giao diện tài liệu API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// KÍCH HOẠT SWAGGER: Chỉ chạy giao diện này khi đang phát triển (Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Cấu hình giao diện xuất hiện ngay tại gốc hoặc đường dẫn /swagger
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();