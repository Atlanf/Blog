import { IPageInfo } from "../shared/interfaces";
import { defaultPageInfoValues } from "../shared/defaultPageInfoValues";

export function adjustPage(pageInfo: IPageInfo): IPageInfo {
    if (pageInfo.page < 1) {
        pageInfo.page = defaultPageInfoValues.page;
    }
    if (pageInfo.pageSize > 20 || pageInfo.pageSize < 3) {
        pageInfo.pageSize = defaultPageInfoValues.pageSize;
    }
    
    return pageInfo;
}