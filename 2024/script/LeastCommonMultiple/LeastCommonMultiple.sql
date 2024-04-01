-- Create a function to calculate LCM
CREATE FUNCTION dbo.CalculateLCM(@a INT, @b INT)
RETURNS INT
AS
BEGIN
	DECLARE @gcd INT;
	DECLARE @lcm INT;

	-- Calculate the Greatest Common Divisor (GCD) using Euclid's Algorithm
	DECLARE @tempA INT = @a;
	DECLARE @tempB INT = @b;

	WHILE @tempB != 0
	BEGIN
		SET @gcd = @tempB;
		SET @tempB = @tempA % @tempB;
		SET @tempA = @gcd;
	END

	-- Calculate the LCM using the formula: LCM(a, b) = (a * b) / GCD(a, b)
	SET @lcm = (@a * @b) / @gcd;

	RETURN @lcm;
END;
GO

-- Example usage
DECLARE @num1 INT = 2;
DECLARE @num2 INT = 3;

SELECT dbo.CalculateLCM(@num1, @num2) AS LCMResult;
