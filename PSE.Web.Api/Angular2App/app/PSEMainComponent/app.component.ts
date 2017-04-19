import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { ImgService } from '../ImagesPulling/img.service';

@Component({
    selector: 'my-app',
    templateUrl: './pse.main.html'
})
export class AppComponent {

    selectedUrl: string;

    constructor(private _http:Http, private _imgSvc: ImgService) {

    }

    pullImages()
    {
        var url = this.selectedUrl;
        this.selectedUrl = 'Processing...'

        this._imgSvc.PullImagesFromUrl(url).subscribe(pullingImgs => {

            this.selectedUrl = `${pullingImgs.DownloadedImagesCount} images out of ${pullingImgs.ImagesCount} downloaded.`;

        },
            error => {
                this.selectedUrl = 'error occured';
            });
    }
}