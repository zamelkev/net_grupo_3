export interface Product {

  id?: number;
  name?: string;
  cost?: number;
  price?: number;
  stock?: number;
  tax?: number;
  releaseDate?: any;

  // Associations
  productComments?: any;
  orders?: any;

}
