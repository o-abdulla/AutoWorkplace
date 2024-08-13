import { Department } from "./department";

export interface Employee {
    employeeId: number;
    firstName: string;
    lastName: string;
    cid?: string;
    email?: string;
    phoneNumber?: string;
    departmentId?: number; // Foreign Key
    department?: Department; // Navigation Property
}
