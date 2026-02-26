-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerProductos 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT Producto.Id, Producto.IdSubCategoria, Producto.Nombre, Producto.Descripcion, Producto.Precio, Producto.CodigoBarras, Producto.Stock
FROM     Categorias INNER JOIN
                  Producto ON Categorias.Id = Producto.Id INNER JOIN
                  SubCategorias ON Categorias.Id = SubCategorias.IdCategoria AND Producto.IdSubCategoria = SubCategorias.Id
END