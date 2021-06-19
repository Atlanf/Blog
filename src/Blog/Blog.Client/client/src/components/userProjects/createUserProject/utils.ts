import { postCreateProject } from "./api";
import { ICreateProjectResponse, ICreateProjectRequest } from "../../../shared/interfaces";

export async function createUserProject(request: ICreateProjectRequest): Promise<ICreateProjectResponse> {
    console.log("Create User Project event fired.");

    let result: ICreateProjectResponse = await postCreateProject(request);

    return result;
}