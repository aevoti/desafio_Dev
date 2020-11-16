export interface Pagination {
  CurrentPage: number;
  PageSize: number;
  TotalCount: number;
  TotalPages: number;
  HasNext: boolean;
  HasPrevious: boolean;
}
