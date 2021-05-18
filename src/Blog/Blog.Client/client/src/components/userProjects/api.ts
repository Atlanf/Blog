import axios from "axios";
import { serverAddress } from "../../shared/apiAddresses"

import { IUserProjectPreview } from "../../shared/interfaces/userProjects.interface"

export async function getUserProjects(
    userName: string
): Promise<IUserProjectPreview[]> {
    let result: IUserProjectPreview[] = [];

    axios.get(serverAddress + "/UserProject/" + userName + "/all")

    return result;
}