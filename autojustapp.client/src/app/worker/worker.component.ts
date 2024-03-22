import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MOCK_WORKERS } from '../models/mock/MOCK_WORKERS';

const MOCK_TABLE_DATA = MOCK_WORKERS;
@Component({
  selector: 'app-worker',
  templateUrl: './worker.component.html',
  styleUrl: './worker.component.css'
})

export class WorkerComponent {


  displayedColumns: string[] = ['ID', 'Name', 'Phone Number', 'Email'];
  dataSource = MOCK_TABLE_DATA;


}
