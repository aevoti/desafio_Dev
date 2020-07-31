export interface PaginatedList<T> {
    page: number,
    pageSize: number,
    totalCount: number,
    items: T[]
}