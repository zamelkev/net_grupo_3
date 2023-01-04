import { OrderDetail } from "./orderDetail.model";
export interface Order {

  id?: number;
  orderTime?: string;
  deliveryTime?: string;
  orderDetails?: OrderDetail[];
  userId?: number;
}
