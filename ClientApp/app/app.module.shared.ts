import { NgModule, ErrorHandler } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule } from "@angular/router";
import { BrowserXhr } from '@angular/http';

import * as Raven from "raven-js";
import { AppComponent } from "./components/app/app.component";
import { NavMenuComponent } from "./components/navmenu/navmenu.component";
import { HomeComponent } from "./components/home/home.component";
import { FetchDataComponent } from "./components/fetchdata/fetchdata.component";
import { CounterComponent } from "./components/counter/counter.component";
import { StudentFormComponent } from "./components/student-form/student-form.component";
import { StudentService } from "./services/student.service";
import { ToastyModule } from "ng2-toasty";
import { AppErrorHandler } from "./app.error-handler";
import { SignFormComponent } from "./components/sign-form/sign-form.component";
import { MatComponentsModule } from "./mat-components.module";
import { StudentListComponent } from "./components/student-list/student-list.component";
import { ViewStudentComponent } from "./components/view-student/view-student.component";
import { PhotoService } from "./services/photo.service";
import { ProgressService } from "./services/progress.service";
import { BrowserXhrWithProgress } from "./services/browserXhr.service"

Raven.config("https://963dd7b18a474ac5938f91c038fcc0c7@sentry.io/996208")
    .install();

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        StudentFormComponent,
        SignFormComponent,
        StudentListComponent,
        ViewStudentComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        MatComponentsModule,
        ToastyModule.forRoot(),
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot([
            { path: "", redirectTo: "home", pathMatch: "full" },
            { path: "home", component: HomeComponent },
            { path: "students/new", component: StudentFormComponent },
            { path: "students/:id", component: StudentFormComponent },
            { path: "students/view/:id", component: ViewStudentComponent },
            { path: "students", component: StudentListComponent },
            { path: "form", component: SignFormComponent },
            { path: "counter", component: CounterComponent },
            { path: "fetch-data", component: FetchDataComponent },
            { path: "**", redirectTo: "home" }
        ])
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: BrowserXhr, useClass: BrowserXhrWithProgress},
        StudentService,
        PhotoService,
        ProgressService
    ]
})
export class AppModuleShared {
}
