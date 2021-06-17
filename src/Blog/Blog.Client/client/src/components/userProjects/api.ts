import axios, { AxiosError } from "axios";

import { addPageInfoToRequest } from "../../utils/pageInfoGenerator";
import parseAxiosError from "../../utils/errorParser";

import { serverAddress } from "../../shared/apiAddresses";
import { IUserProjectPreview, IPageInfo, IProjectPreviews, IPaginatedList } from "../../shared/interfaces/";

export async function getUserProjects(
    userName: string,
    pageInfo?: IPageInfo
): Promise<IProjectPreviews> {
    let result: IProjectPreviews = {} as IProjectPreviews;
    let requestString: string = serverAddress + "userproject/" + userName + "/all";
    
    if (pageInfo !== undefined) {
        requestString = addPageInfoToRequest(requestString, pageInfo);
    }

    await axios.get<IPaginatedList<IUserProjectPreview>>(requestString)
        .then(response => {
            result = { userProjectPreviews: response.data, error: false, isLoading: false };
        })
        .catch((error: AxiosError) => {
            parseAxiosError(error, "GET", requestString);
            result = {userProjectPreviews: {} as IPaginatedList<IUserProjectPreview>, error: true, isLoading: false };
        });

    return result;
}