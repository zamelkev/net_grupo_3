import { Product } from "./product.model";
export interface OrderDetail {


  id?: number;
  productId?: number;
  quantity?: number;
  product?: Product;
}
