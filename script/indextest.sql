CREATE TABLE Employees
(
	Id int primary key identity,
	[Name] nvarchar(50),
	Email nvarchar(50),
	Department nvarchar(50)
)

SET NOCOUNT ON

Declare @counter int = 1

While(@counter <= 1000000)
Begin
  Declare @Name nvarchar(50) = 'ABC ' + RTRIM(@counter)
  Declare @Email nvarchar(50) = 'abc' + RTRIM(@counter) + '@pragimtech.com'
  Declare @Dept nvarchar(10) = 'Dept ' + RTRIM(@counter)

  Insert into Employees values (@Name, @Email, @Dept)

  Set @counter = @counter + 1
  If (@Counter%100000 = 0)
       Print RTRIM(@Counter) + ' rows inserted'
End   

SELECT * FROM Employees Where Id = 932000

SELECT * FROM Employees Where [Name] = 'ABC 932000'

CREATE NONCLUSTERED INDEX IX_Employees_Name ON [dbo].[Employees] ([Name])