import axios from "axios";

import { adjustPage } from "../../utils/pageAdjuster";
import { generatePageInfoRequest } from "../../utils/pageInfoGenerator";
import errorParser from "../../utils/errorParser";

import { serverAddress } from "../../shared/apiAddresses";
import { IUserProjectPreview, IPageInfo } from "../../shared/interfaces/";

export async function getUserProjects(
    userName: string,
    pageInfo?: IPageInfo
): Promise<IUserProjectPreview[]> {
    let result: IUserProjectPreview[] = [];
    let requestString: string = serverAddress + "/userproject/" + userName + "/all";

    axios.get(requestString)

    return result;
}