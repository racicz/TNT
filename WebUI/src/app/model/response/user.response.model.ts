import { ResponseDto } from "../base.model";

export interface RegistrationResponseDto extends ResponseDto {
    isSuccessfulRegistration: boolean;
}