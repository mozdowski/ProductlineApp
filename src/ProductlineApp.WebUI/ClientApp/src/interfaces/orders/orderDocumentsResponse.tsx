export interface OrderDocumentsResponse {
  orderDocuments: OrderDocument[];
}

export interface OrderDocument {
  id: string;
  name: string;
  url: string;
}
