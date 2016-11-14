export enum AuthenticationMode {
    None,
    Require
};
export const Languages = {
    EN: "en",
    VN: "vn"
};
export enum IoCType {
    IConnector
};
export enum FormSelectMode {
    Group,
    Item
};
export enum FormMode {
    AddNew,
    Edit
};
export enum ItemStatus {
    None = 0,
    InActive = 1,
    Active = 2,
    Deleted = 3,
    WaitForActivating = 4,
    WaitForApproving = 5,
    New = 6,
    Resolved = 7,
    Cancelled = 8

};
export enum InputValueType {
    Text,
    Currency
};
export enum HttpStatusCode {
    OK = 200
};
export const Guid = {
    Empty: "00000000-0000-0000-0000-000000000000"
};
export enum DisplayMode {
    View = 0,
    Edit = 1,
    Add = 4
};
export enum ParameterValueType {
    String,
    Number,
    Password
};
export const IoCNames = {
    ILogger: "ILogger",
    IConnector: "IConnector",
    IEventManager: "IEventManager",
    IResource: "IResource",
    IApplicationState: "IApplicationState",
};
export const enum MaxLenghtForFields {
    Name = 50,
    Description = 512
};