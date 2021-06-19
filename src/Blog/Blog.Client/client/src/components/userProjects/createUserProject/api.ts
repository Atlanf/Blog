import axios, { AxiosError } from "axios";
import { ICreateProjectRequest, ICreateProjectResponse } from "../../../shared/interfaces";
import { serverAddress } from "../../../shared/apiAddresses";
import parseAxiosError from "../../../utils/errorParser";

const requestAddress: string = serverAddress + "userproject/create";

export async function postCreateProject(request: ICreateProjectRequest): Promise<ICreateProjectResponse> {
    let result: ICreateProjectResponse = {} as ICreateProjectResponse;

    await axios.post<ICreateProjectResponse>(requestAddress, request).then(response => {
        result = response.data;
    }).catch((error: AxiosError) => {
        parseAxiosError(error, "POST", requestAddress, request);
        result.isSuccess = false;
        result.errors = [];
        result.errors.push(error.message);
    });

    return result;
}