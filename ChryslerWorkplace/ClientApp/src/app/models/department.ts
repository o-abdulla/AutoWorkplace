import { Employee } from "./employee";

export interface Department {
    departmentId: number;
    departmentName: string;
    departmentNumber?: string;
    employees?: Employee[];
}
