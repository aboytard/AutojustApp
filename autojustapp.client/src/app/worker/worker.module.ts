import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkerComponent } from './worker.component';
import { MatTableModule } from '@angular/material/table';




@NgModule({
  declarations: [
    WorkerComponent
  ],
  imports: [
    CommonModule,
    MatTableModule
  ],
  exports: [
    WorkerComponent
  ]
})
export class WorkerModule { }
