import { Component } from '@angular/core';
import { HttpService } from '../core/service/http.service';
import { ApiEndpointService } from '../core/service/api-endpoint.service';

@Component({
  selector: 'app-tool',
  templateUrl: './tool.component.html',
  styleUrls: ['./tool.component.css'],
})
export class ToolComponent {
  nodToComplete?: number;
  completionDate?: Date;
  selectedDate: Date = new Date();

  constructor(private httpService: HttpService, private apiEndpointsService: ApiEndpointService) {}

  GetCompletionDtae() {
    if (this.nodToComplete) {
      const dateStr = this.getYYYYMMDDStrDateFromDate(this.selectedDate);
      this.httpService
      .get(this.apiEndpointsService.createUrl(`TaskManager/${dateStr}/${this.nodToComplete}`))
      .subscribe((response: any) => {
        this.completionDate = new Date(response as string);
      });
    }
  }

  private getYYYYMMDDStrDateFromDate(date: Date) {
    // Get year, month, and day part from the date
    var year = date.toLocaleString('default', { year: 'numeric' });
    var month = date.toLocaleString('default', { month: '2-digit' });
    var day = date.toLocaleString('default', { day: '2-digit' });

    // Generate yyyy-mm-dd date string
    var formattedDate = year + '-' + month + '-' + day;
    return formattedDate;
  }
}
