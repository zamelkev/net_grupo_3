﻿namespace net_grupo_3.Models;

[Table("product")]
public class Product {
    // atributos
    [Key, 
    Column("id")]
    public int Id { get; set; }

    [
    Column("name")]
    public string Name { get; set; }

    [ 
    Column("Cost")]
    public Double Cost { get; set; }

    [ 
    Column("price")]
    public Double Price { get; set; }

    [ 
    Column("stock")]
    public int Stock { get; set; }

    [ 
    Column("tax")]
    public Double Tax { get; set; }

    [ 
    Column("date")]
    public DateTime ReleaseDate { get; set; }

    [ 
    Column("comment")]
    public IList<ProductComment>? ProductComments { get; set; }
    //ProductComment? comment { get; set; }

}
