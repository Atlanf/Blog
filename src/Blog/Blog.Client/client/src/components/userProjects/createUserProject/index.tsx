import React from "react";
import { Form, Formik, withFormik, Field } from "formik";
import * as Yup from "yup";

import { createUserProject } from "./utils";
import { ICreateProjectRequest } from "../../../shared/interfaces";

export const CreateUserProject: React.FC = () => {
    const initialValues: ICreateProjectRequest = { title: "", description: "" };
 
    return (
        <div>
            <Formik initialValues={initialValues} onSubmit={createUserProject} validationSchema={createUserProjectValidationSchema}>
                {({errors, touched}) => (
                    <Form>
                        <label htmlFor="title" title="Project title" />
                        <Field type="text" name="title" placeholder="Enter project title" />
                        { errors.title && touched.title ? (
                            <div>{errors.title}</div>
                        ): null}

                        <label htmlFor="description" title="Project description" />
                        <Field type="text" name="description" placeholder="Enter project description (optional)" />
                        { errors.description && touched.title ? (
                            <div>{errors.description}</div>
                        ): null}

                        <button type="submit">Create</button>
                    </Form>
                )}
            </Formik>
        </div>
    )
}

const createUserProjectValidationSchema = Yup.object().shape({
    title: Yup.string()
        .min(10, "Title must be at least 10 characters.")
        .max(50, "Title must be shorter than 50 characters.")
        .required("Required"),
    description: Yup.string()
        .max(255, "Description must be shorter than 255 characters.")
});