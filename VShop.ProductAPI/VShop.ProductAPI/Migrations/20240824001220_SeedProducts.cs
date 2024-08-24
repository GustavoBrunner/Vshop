using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('3B5864D4-D020-4755-AFAA-33C9EC907E11', 5.50, 'Mamão', '',  30, '3255b7f7-ec73-4911-8429-69f8dac47872') ");
            
            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('DA655CA7-31EC-481F-9DCB-68D249E7F770', 10.50, 'NoteBook',' ', 100, '7e054430-8cd7-4615-9b46-545ad98faf55') ");

            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('06D259CC-E8F7-450E-B895-C541B76E934F', 0.50, 'Pen',' ', 100, '7e054430-8cd7-4615-9b46-545ad98faf55') ");

            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('8F628592-7025-4FA0-9395-3414F0F223FF', 4.50, 'Paper (100)',' ', 100, '7e054430-8cd7-4615-9b46-545ad98faf55') ");


            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('5D4678B6-2F0F-4048-A083-24B61DC71AB5', 7.50, 'Chicken meat',' ', 100, '3255b7f7-ec73-4911-8429-69f8dac47872') ");


            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('E6208A4C-0890-4D40-BB44-6FE0DA747B3F', 210.50, 'Tech T-shirt',' ', 300, 'dcb1eea1-34f2-4043-b6c4-d3f53ea78b79') ");

            mB.Sql("INSERT INTO products(PK_product_id, price, name, description, stock, FK_category_id) " +
                "VALUES('F4F2756D-62E3-4F75-AE74-947E5F22B9CB', 110.50, 'Jeans',' ', 240, 'dcb1eea1-34f2-4043-b6c4-d3f53ea78b79') ");
        }


        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("DELETE FROM products");
        }
    }
}
