import {IoCInstanceType} from "../common/models/ioc/enum";
import {RESTConnector} from "../common/connectors/restConnector";
import {EventManager} from "../common/EventManager";
import {ResourceHelper} from "../common/helpers/resourceHelper";
import {ApplicationState, ApplicationStateFactory} from "../applicationState";
import {ConsoleLogger} from "../common/helpers/logging/consoleLogger";
import {IoCNames} from "../common/enum";

let iocRegistrations: any = [
    { name: IoCNames.ILogger, instanceOf: ConsoleLogger, type: IoCInstanceType.Transient },
    { name: IoCNames.IConnector, instanceOf: RESTConnector, type: IoCInstanceType.Singleton },
    { name: IoCNames.IEventManager, instanceOf: EventManager, type: IoCInstanceType.Singleton },
    { name: IoCNames.IResource, instanceOf: ResourceHelper, type: IoCInstanceType.Singleton },
    { name: IoCNames.IApplicationState, instance: ApplicationStateFactory.getInstance(), type: IoCInstanceType.Singleton },
];
export default iocRegistrations;