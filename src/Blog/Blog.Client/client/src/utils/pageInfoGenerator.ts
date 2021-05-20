import { IPageInfo } from "../shared/interfaces";

import { adjustPage } from "./pageAdjuster";

import { defaultPageInfoValues } from "../shared/defaultPageInfoValues";

export function generatePageInfoRequest(baseRequest: string, pageInfo: IPageInfo) {
    pageInfo = adjustPage(pageInfo);
    let key: keyof typeof pageInfo;
    let sign: string;
    
    for (key in pageInfo) {
        if (pageInfo[key] !== defaultPageInfoValues[key]) {
            if (!baseRequest.includes("?")) {
                sign = "?";
            }
            else {
                sign = "&";
            }
            baseRequest += sign + key.toString() + "=" + pageInfo[key];
        }
    }
}