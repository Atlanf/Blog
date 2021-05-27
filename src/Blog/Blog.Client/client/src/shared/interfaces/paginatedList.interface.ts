export interface IPaginatedList<T> {
    items: Array<T>,
    pageIndex: number,
    pageCount: number,
    hasPreviousPage: boolean,
    hasNextPage: boolean
}