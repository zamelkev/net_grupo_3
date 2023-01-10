import { Product } from "./product.model";

export interface ProductsCart extends Product {
  quantity: number;
}
