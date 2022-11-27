export interface Product {

  id?: number;
  name?: string;
  cost?: number;
  price?: number;
  stock?: number;
  tax?: number;
  releaseDate?: any;

  cpu?: string;
  ram?: number;
  graphicCard?: string;

  imgUrl: string;
  slug: string;

  // Associations
  productComments?: any;
  orders?: any;

}
