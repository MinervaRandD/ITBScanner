Imports System.Security.Cryptography
Imports System.IO
Module ModuleMain

#Region "Master Key"
    Public MyMaster() As Byte = { _
            56, 221, 9, 148, 177, 136, 210, 238, 68, 150, 181, 91, 155, 117, 22, 70, _
          137, 81, 17, 63, 49, 225, 246, 84, 172, 99, 12, 44, 4, 210, 228, 172, _
           32, 115, 24, 50, 233, 19, 173, 43, 163, 35, 174, 151, 24, 250, 248, 60, _
          142, 155, 138, 36, 138, 145, 188, 120, 80, 203, 210, 200, 226, 91, 50, 49, _
           40, 186, 116, 82, 39, 231, 228, 225, 71, 247, 122, 39, 176, 34, 126, 113, _
          178, 96, 59, 230, 135, 119, 50, 145, 215, 18, 70, 183, 246, 116, 49, 220, _
           63, 233, 51, 83, 81, 168, 184, 217, 249, 25, 102, 67, 150, 195, 35, 65, _
           37, 223, 34, 109, 176, 17, 164, 116, 152, 138, 230, 54, 60, 155, 131, 147, _
          207, 230, 251, 43, 183, 192, 77, 70, 123, 56, 177, 217, 97, 116, 212, 211, _
          148, 5, 130, 50, 213, 245, 62, 186, 188, 107, 140, 220, 223, 191, 44, 244, _
           78, 165, 210, 113, 41, 154, 4, 77, 89, 254, 47, 161, 21, 126, 83, 225, _
          213, 51, 9, 130, 39, 100, 225, 72, 41, 139, 115, 84, 95, 45, 81, 225, _
          179, 240, 7, 187, 66, 241, 157, 98, 252, 223, 243, 50, 138, 28, 44, 187, _
          206, 188, 213, 34, 23, 71, 49, 126, 71, 153, 245, 175, 232, 235, 39, 212, _
           84, 130, 143, 63, 179, 22, 128, 109, 146, 178, 73, 34, 168, 149, 35, 250, _
          204, 96, 219, 181, 196, 45, 196, 223, 80, 62, 185, 140, 20, 212, 215, 115, _
           16, 97, 25, 207, 96, 7, 216, 80, 226, 204, 49, 91, 245, 25, 181, 134, _
           98, 232, 164, 119, 87, 108, 71, 177, 244, 96, 44, 12, 169, 14, 189, 47, _
          242, 156, 203, 219, 84, 213, 122, 146, 138, 15, 115, 173, 45, 224, 165, 40, _
          101, 90, 97, 109, 198, 121, 223, 123, 126, 245, 34, 43, 52, 69, 176, 147, _
          177, 59, 15, 137, 179, 52, 237, 148, 181, 161, 43, 131, 185, 106, 158, 86, _
          134, 44, 188, 153, 79, 99, 26, 164, 189, 147, 15, 31, 203, 11, 126, 154, _
          174, 16, 233, 38, 156, 144, 165, 99, 165, 160, 47, 98, 44, 11, 118, 53, _
          122, 73, 44, 128, 16, 151, 61, 144, 6, 143, 225, 168, 187, 46, 166, 218, _
          242, 149, 70, 107, 189, 62, 193, 78, 57, 21, 172, 218, 21, 219, 69, 211, _
          249, 55, 252, 199, 208, 130, 233, 227, 35, 61, 221, 222, 174, 15, 171, 11, _
          185, 169, 42, 1, 114, 202, 14, 136, 235, 43, 16, 153, 164, 136, 193, 54, _
          118, 102, 184, 150, 59, 0, 170, 121, 56, 56, 90, 196, 50, 57, 191, 121, _
          223, 231, 198, 54, 241, 237, 49, 29, 97, 26, 238, 230, 204, 148, 157, 64, _
           38, 155, 222, 17, 53, 82, 206, 91, 6, 8, 147, 178, 222, 153, 247, 104, _
          154, 133, 87, 186, 192, 142, 28, 78, 228, 135, 179, 150, 100, 229, 166, 227, _
          149, 251, 50, 160, 239, 45, 184, 67, 9, 23, 26, 179, 171, 250, 67, 240, _
          152, 204, 21, 235, 240, 203, 86, 99, 178, 253, 38, 12, 219, 237, 143, 189, _
          128, 61, 99, 242, 103, 100, 197, 129, 169, 30, 229, 124, 178, 38, 57, 55, _
          172, 82, 11, 44, 88, 144, 215, 137, 208, 68, 159, 162, 82, 67, 162, 152, _
           59, 38, 160, 212, 147, 134, 117, 159, 47, 91, 196, 178, 106, 160, 34, 73, _
          242, 72, 152, 16, 167, 29, 158, 77, 155, 234, 236, 153, 230, 77, 133, 24, _
           64, 160, 95, 238, 227, 56, 212, 220, 101, 47, 131, 138, 158, 2, 3, 9, _
           49, 209, 241, 158, 146, 53, 128, 3, 132, 61, 200, 72, 188, 12, 77, 79, _
           59, 90, 60, 123, 99, 98, 192, 73, 66, 254, 140, 216, 32, 248, 109, 152, _
          112, 210, 134, 91, 5, 157, 40, 247, 128, 168, 86, 174, 16, 53, 92, 114, _
           37, 48, 136, 19, 64, 65, 198, 149, 220, 108, 157, 117, 217, 61, 70, 55, _
           19, 119, 163, 107, 106, 66, 52, 87, 65, 32, 97, 132, 223, 21, 3, 168, _
           95, 59, 189, 135, 248, 111, 122, 199, 68, 178, 220, 202, 159, 53, 76, 152, _
          164, 206, 219, 36, 47, 11, 202, 40, 36, 247, 161, 13, 23, 60, 1, 104, _
          197, 152, 230, 15, 139, 152, 205, 177, 96, 113, 220, 153, 10, 36, 223, 137, _
          188, 208, 61, 139, 28, 19, 248, 204, 97, 218, 82, 117, 117, 187, 189, 198, _
           87, 203, 81, 115, 214, 143, 162, 31, 174, 212, 26, 23, 27, 8, 96, 7, _
          135, 119, 154, 180, 224, 75, 232, 104, 200, 149, 145, 74, 164, 138, 120, 106, _
           59, 1, 100, 149, 69, 133, 208, 242, 88, 99, 232, 110, 110, 88, 166, 104, _
          216, 224, 100, 165, 168, 231, 197, 246, 31, 188, 98, 247, 175, 108, 173, 112, _
          113, 223, 31, 111, 136, 17, 38, 23, 148, 2, 102, 245, 81, 255, 129, 152, _
          191, 63, 154, 73, 104, 195, 51, 205, 53, 210, 193, 157, 86, 80, 143, 252, _
           46, 50, 178, 211, 83, 13, 87, 159, 223, 215, 110, 129, 58, 69, 60, 85, _
          177, 138, 57, 102, 32, 198, 134, 125, 105, 173, 97, 128, 125, 18, 121, 150, _
          176, 180, 81, 166, 104, 188, 220, 87, 0, 112, 19, 17, 207, 96, 160, 181, _
           88, 135, 239, 223, 137, 177, 207, 221, 127, 53, 49, 51, 141, 201, 247, 156, _
           93, 245, 247, 240, 66, 190, 53, 247, 233, 47, 166, 99, 21, 109, 203, 252, _
           19, 105, 93, 131, 101, 197, 29, 61, 173, 0, 158, 136, 31, 162, 137, 32, _
          131, 24, 3, 88, 88, 226, 48, 240, 136, 179, 29, 27, 41, 203, 141, 78, _
          197, 211, 43, 20, 179, 234, 212, 111, 180, 103, 10, 183, 44, 79, 211, 247, _
          207, 227, 177, 236, 174, 92, 147, 208, 243, 7, 24, 160, 94, 78, 132, 76, _
           36, 110, 114, 69, 147, 161, 219, 167, 196, 137, 57, 224, 17, 4, 16, 142, _
          202, 211, 201, 216, 9, 18, 70, 160, 10, 91, 42, 203, 72, 36, 111, 55, 32, _
        112, 248, 14, 228, 241, 210, 66, 153, 202, 171, 239, 246, 30, 165, 55, 31, 80, 152, 48, 158, 175, 96, 56, 86, 183, _
        170, 11, 132, 195, 84, 161, 125, 234, 81, 23, 249, 2, 68, 195, 52, 181, 244, 3, 45, 13, 158, 195, 240, 120, 196, _
        170, 105, 35, 62, 76, 23, 70, 52, 91, 116, 61, 167, 170, 210, 113, 170, 147, 96, 164, 27, 66, 114, 153, 113, 210, _
        119, 167, 91, 248, 227, 234, 12, 98, 152, 196, 53, 104, 48, 223, 19, 38, 108, 225, 124, 73, 93, 124, 105, 238, 28, _
        167, 123, 221, 66, 237, 181, 149, 37, 72, 178, 240, 239, 76, 225, 101, 22, 86, 26, 200, 98, 91, 117, 36, 68, 28, _
        1, 172, 201, 127, 183, 244, 199, 207, 171, 28, 56, 107, 20, 224, 143, 236, 92, 78, 207, 162, 13, 252, 68, 203, 11, _
        71, 239, 137, 125, 93, 148, 78, 202, 99, 120, 107, 145, 252, 128, 81, 110, 1, 120, 255, 144, 204, 197, 53, 162, 170, _
        127, 89, 146, 127, 140, 59, 105, 107, 234, 232, 81, 92, 9, 32, 182, 122, 183, 7, 231, 231, 21, 20, 98, 141, 216, _
        95, 103, 46, 161, 63, 57, 99, 113, 125, 208, 231, 81, 79, 72, 105, 36, 147, 1, 178, 76, 135, 222, 253, 189, 217, _
        43, 157, 15, 81, 254, 209, 205, 61, 14, 171, 214, 36, 223, 36, 72, 96, 190, 247, 160, 83, 46, 226, 230, 238, 202, _
        105, 18, 12, 136, 94, 68, 253, 74, 31, 223, 218, 225, 12, 74, 220, 177, 132, 108, 155, 225, 116, 130, 139, 219, 133, _
        211, 215, 70, 247, 168, 190, 229, 4, 127, 199, 103, 93, 71, 177, 247, 202, 186, 196, 73, 247, 22, 233, 203, 201, 1, _
        232, 21, 108, 45, 35, 64, 131, 249, 80, 211, 95, 186, 180, 223, 195, 15, 231, 72, 157, 152, 207, 218, 151, 152, 70, _
        13, 172, 234, 103, 225, 230, 210, 193, 105, 77, 108, 50, 86, 224, 18, 158, 56, 199, 181, 105, 123, 15, 36, 185, 36, _
        0, 85, 244, 143, 211, 73, 189, 121, 217, 192, 196, 57, 119, 173, 13, 178, 98, 107, 198, 176, 252, 225, 57, 225, 16, _
        189, 136, 195, 222, 137, 28, 144, 121, 172, 87, 191, 34, 38, 168, 140, 49, 61, 166, 9, 56, 132, 62, 68, 102, 141, _
        30, 64, 31, 104, 234, 25, 120, 94, 218, 127, 199, 57, 23, 193, 4, 4, 24, 186, 55, 70, 35, 51, 96, 205, 97, _
        36, 124, 221, 110, 126, 43, 226, 163, 246, 17, 73, 184, 163, 65, 80, 9, 172, 244, 216, 79, 78, 11, 152, 83, 51, _
        80, 19, 147, 2, 237, 191, 84, 104, 229, 83, 127, 55, 215, 147, 38, 166, 99, 171, 11, 205, 211, 228, 251, 31, 233, _
        228, 51, 37, 21, 59, 42, 95, 86, 252, 89, 147, 79, 178, 52, 234, 102, 190, 83, 128, 192, 172, 176, 226, 154, 56, _
        186, 49, 109, 78, 68, 59, 87, 64, 196, 25, 242, 238, 174, 90, 185, 205, 226, 97, 1, 50, 35, 119, 39, 89, 115, _
        211, 38, 9, 240, 235, 243, 255, 181, 210, 195, 73, 14, 196, 42, 212, 246, 29, 84, 44, 30, 207, 244, 244, 177, 89, _
        126, 188, 226, 208, 176, 25, 43, 230, 152, 110, 183, 124, 140, 81, 57, 86, 229, 123, 186, 7, 149, 66, 96, 159, 170, _
        238, 6, 73, 236, 201, 189, 136, 149, 63, 206, 140, 12, 71, 174, 129, 110, 120, 134, 118, 45, 181, 251, 232, 17, 205, _
        37, 52, 18, 180, 220, 24, 8, 235, 124, 177, 161, 14, 223, 53, 25, 101, 171, 86, 181, 25, 42, 133, 212, 247, 242, _
        241, 198, 168, 172, 151, 64, 174, 197, 254, 88, 169, 164, 74, 81, 87, 112, 58, 126, 33, 6, 201, 115, 71, 191, 195, _
        193, 179, 186, 236, 61, 166, 198, 104, 79, 178, 105, 135, 210, 80, 80, 21, 184, 229, 175, 150, 19, 44, 247, 11, 39, _
        168, 33, 212, 160, 100, 153, 245, 72, 76, 49, 182, 122, 58, 237, 154, 108, 102, 200, 207, 222, 106, 242, 126, 193, 2, _
        254, 235, 116, 1, 113, 85, 157, 51, 253, 225, 210, 187, 151, 109, 70, 133, 186, 75, 167, 251, 171, 116, 248, 132, 58, _
        34, 162, 179, 90, 154, 211, 128, 158, 197, 188, 198, 77, 66, 29, 80, 235, 36, 236, 157, 13, 39, 14, 167, 123, 96, _
        240, 25, 98, 207, 220, 230, 221, 241, 99, 171, 92, 185, 12, 48, 108, 240, 153, 72, 40, 82, 47, 42, 39, 236, 147, _
        242, 16, 175, 17, 122, 40, 156, 21, 244, 243, 47, 159, 70, 28, 100, 96, 156, 92, 211, 49, 167, 38, 48, 136, 76, _
        203, 138, 157, 120, 146, 149, 144, 235, 234, 149, 242, 110, 108, 250, 33, 250, 217, 215, 235, 74, 157, 25, 30, 252, 94, _
        119, 180, 141, 92, 0, 255, 27, 17, 76, 203, 227, 204, 135, 34, 113, 196, 138, 36, 130, 30, 253, 166, 60, 189, 84, _
        89, 9, 235, 212, 225, 221, 18, 39, 87, 203, 3, 41, 32, 145, 98, 165, 31, 118, 105, 127, 132, 63, 161, 70, 220, _
        138, 115, 198, 96, 236, 31, 36, 45, 121, 176, 28, 188, 52, 92, 138, 70, 165, 136, 60, 208, 124, 172, 71, 250, 244, _
        230, 181, 140, 133, 202, 228, 18, 67, 25, 80, 187, 248, 223, 95, 100, 48, 218, 109, 130, 136, 93, 155, 178, 175, 167, _
        15, 253, 157, 237, 205, 172, 3, 26, 223, 68, 243, 57, 111, 168, 151, 1, 78, 0, 181, 15, 69, 103, 108, 144, 35, _
        137, 166, 247, 124, 174, 45, 117, 29, 150, 200, 52, 205, 37, 48, 248, 231, 58, 147, 189, 2, 26, 101, 106, 209, 239, _
        217, 20, 85, 17, 23, 90, 242, 179, 75, 109, 246, 32, 49, 67, 149, 53, 191, 209, 100, 242, 8, 238, 166, 13, 1, _
        203, 52, 123, 6, 170, 193, 254, 230, 208, 67, 37, 210, 46, 112, 146, 248, 59, 37, 121, 198, 80, 79, 10, 87, 75, _
        12, 83, 245, 228, 56, 64, 146, 149, 221, 171, 178, 45, 26, 165, 163, 213, 139, 169, 130, 231, 18, 57, 120, 196, 195, _
        127, 4, 35, 100, 214, 21, 65, 180, 138, 149, 194, 107, 90, 7, 24, 11, 133, 202, 244, 36, 61, 164, 130, 105, 163, _
       170, 154, 27, 53, 36, 130, 57, 187, 128, 179, 95, 190, 50, 39, 83, 105, 9, 148, 185, 172, 17, 157, 160, 241, 28, _
        76, 216, 202, 6, 81, 194, 130, 188, 223, 147, 196, 63, 153, 211, 121, 124, 137, 243, 119, 68, 149, 151, 36, 191, 126, _
        26, 167, 154, 164, 174, 220, 176, 9, 238, 13, 55, 97, 85, 215, 85, 82, 211, 161, 82, 73, 79, 202, 109, 127, 118, _
        244, 255, 33, 108, 247, 240, 13, 247, 137, 117, 211, 189, 120, 187, 161, 177, 17, 127, 90, 5, 237, 145, 57, 136, 6, _
        136, 218, 84, 82, 183, 248, 138, 228, 51, 197, 30, 252, 202, 38, 226, 117, 33, 193, 16, 122, 95, 227, 50, 204, 167, _
        57, 178, 31, 189, 1, 208, 124, 100, 246, 99, 187, 56, 113, 57, 234, 242, 8, 137, 4, 167, 53, 91, 230, 59, 57, _
        16, 14, 103, 68, 150, 120, 131, 5, 4, 207, 56, 146, 250, 112, 29, 212, 53, 72, 183, 72, 76, 21, 51, 173, 15, _
        173, 85, 96, 129, 86, 34, 16, 210, 129, 60, 66, 190, 93, 241, 77, 214, 52, 179, 21, 241, 214, 181, 188, 7, 46, _
        66, 67, 109, 108, 157, 86, 188, 161, 83}

    Public resetMaster() As Byte = { _
        56, 221, 9, 148, 177, 136, 210, 238, 68, 150, 181, 91, 155, 117, 22, 70, _
      137, 81, 17, 63, 49, 225, 246, 84, 172, 99, 12, 44, 4, 210, 228, 172, _
       32, 115, 24, 50, 233, 19, 173, 43, 163, 35, 174, 151, 24, 250, 248, 60, _
      142, 155, 138, 36, 138, 145, 188, 120, 80, 203, 210, 200, 226, 91, 50, 49, _
       40, 186, 116, 82, 39, 231, 228, 225, 71, 247, 122, 39, 176, 34, 126, 113, _
      178, 96, 59, 230, 135, 119, 50, 145, 215, 18, 70, 183, 246, 116, 49, 220, _
       63, 233, 51, 83, 81, 168, 184, 217, 249, 25, 102, 67, 150, 195, 35, 65, _
       37, 223, 34, 109, 176, 17, 164, 116, 152, 138, 230, 54, 60, 155, 131, 147, _
      207, 230, 251, 43, 183, 192, 77, 70, 123, 56, 177, 217, 97, 116, 212, 211, _
      148, 5, 130, 50, 213, 245, 62, 186, 188, 107, 140, 220, 223, 191, 44, 244, _
       78, 165, 210, 113, 41, 154, 4, 77, 89, 254, 47, 161, 21, 126, 83, 225, _
      213, 51, 9, 130, 39, 100, 225, 72, 41, 139, 115, 84, 95, 45, 81, 225, _
      179, 240, 7, 187, 66, 241, 157, 98, 252, 223, 243, 50, 138, 28, 44, 187, _
      206, 188, 213, 34, 23, 71, 49, 126, 71, 153, 245, 175, 232, 235, 39, 212, _
       84, 130, 143, 63, 179, 22, 128, 109, 146, 178, 73, 34, 168, 149, 35, 250, _
      204, 96, 219, 181, 196, 45, 196, 223, 80, 62, 185, 140, 20, 212, 215, 115, _
       16, 97, 25, 207, 96, 7, 216, 80, 226, 204, 49, 91, 245, 25, 181, 134, _
       98, 232, 164, 119, 87, 108, 71, 177, 244, 96, 44, 12, 169, 14, 189, 47, _
      242, 156, 203, 219, 84, 213, 122, 146, 138, 15, 115, 173, 45, 224, 165, 40, _
      101, 90, 97, 109, 198, 121, 223, 123, 126, 245, 34, 43, 52, 69, 176, 147, _
      177, 59, 15, 137, 179, 52, 237, 148, 181, 161, 43, 131, 185, 106, 158, 86, _
      134, 44, 188, 153, 79, 99, 26, 164, 189, 147, 15, 31, 203, 11, 126, 154, _
      174, 16, 233, 38, 156, 144, 165, 99, 165, 160, 47, 98, 44, 11, 118, 53, _
      122, 73, 44, 128, 16, 151, 61, 144, 6, 143, 225, 168, 187, 46, 166, 218, _
      242, 149, 70, 107, 189, 62, 193, 78, 57, 21, 172, 218, 21, 219, 69, 211, _
      249, 55, 252, 199, 208, 130, 233, 227, 35, 61, 221, 222, 174, 15, 171, 11, _
      185, 169, 42, 1, 114, 202, 14, 136, 235, 43, 16, 153, 164, 136, 193, 54, _
      118, 102, 184, 150, 59, 0, 170, 121, 56, 56, 90, 196, 50, 57, 191, 121, _
      223, 231, 198, 54, 241, 237, 49, 29, 97, 26, 238, 230, 204, 148, 157, 64, _
       38, 155, 222, 17, 53, 82, 206, 91, 6, 8, 147, 178, 222, 153, 247, 104, _
      154, 133, 87, 186, 192, 142, 28, 78, 228, 135, 179, 150, 100, 229, 166, 227, _
      149, 251, 50, 160, 239, 45, 184, 67, 9, 23, 26, 179, 171, 250, 67, 240, _
      152, 204, 21, 235, 240, 203, 86, 99, 178, 253, 38, 12, 219, 237, 143, 189, _
      128, 61, 99, 242, 103, 100, 197, 129, 169, 30, 229, 124, 178, 38, 57, 55, _
      172, 82, 11, 44, 88, 144, 215, 137, 208, 68, 159, 162, 82, 67, 162, 152, _
       59, 38, 160, 212, 147, 134, 117, 159, 47, 91, 196, 178, 106, 160, 34, 73, _
      242, 72, 152, 16, 167, 29, 158, 77, 155, 234, 236, 153, 230, 77, 133, 24, _
       64, 160, 95, 238, 227, 56, 212, 220, 101, 47, 131, 138, 158, 2, 3, 9, _
       49, 209, 241, 158, 146, 53, 128, 3, 132, 61, 200, 72, 188, 12, 77, 79, _
       59, 90, 60, 123, 99, 98, 192, 73, 66, 254, 140, 216, 32, 248, 109, 152, _
      112, 210, 134, 91, 5, 157, 40, 247, 128, 168, 86, 174, 16, 53, 92, 114, _
       37, 48, 136, 19, 64, 65, 198, 149, 220, 108, 157, 117, 217, 61, 70, 55, _
       19, 119, 163, 107, 106, 66, 52, 87, 65, 32, 97, 132, 223, 21, 3, 168, _
       95, 59, 189, 135, 248, 111, 122, 199, 68, 178, 220, 202, 159, 53, 76, 152, _
      164, 206, 219, 36, 47, 11, 202, 40, 36, 247, 161, 13, 23, 60, 1, 104, _
      197, 152, 230, 15, 139, 152, 205, 177, 96, 113, 220, 153, 10, 36, 223, 137, _
      188, 208, 61, 139, 28, 19, 248, 204, 97, 218, 82, 117, 117, 187, 189, 198, _
       87, 203, 81, 115, 214, 143, 162, 31, 174, 212, 26, 23, 27, 8, 96, 7, _
      135, 119, 154, 180, 224, 75, 232, 104, 200, 149, 145, 74, 164, 138, 120, 106, _
       59, 1, 100, 149, 69, 133, 208, 242, 88, 99, 232, 110, 110, 88, 166, 104, _
      216, 224, 100, 165, 168, 231, 197, 246, 31, 188, 98, 247, 175, 108, 173, 112, _
      113, 223, 31, 111, 136, 17, 38, 23, 148, 2, 102, 245, 81, 255, 129, 152, _
      191, 63, 154, 73, 104, 195, 51, 205, 53, 210, 193, 157, 86, 80, 143, 252, _
       46, 50, 178, 211, 83, 13, 87, 159, 223, 215, 110, 129, 58, 69, 60, 85, _
      177, 138, 57, 102, 32, 198, 134, 125, 105, 173, 97, 128, 125, 18, 121, 150, _
      176, 180, 81, 166, 104, 188, 220, 87, 0, 112, 19, 17, 207, 96, 160, 181, _
       88, 135, 239, 223, 137, 177, 207, 221, 127, 53, 49, 51, 141, 201, 247, 156, _
       93, 245, 247, 240, 66, 190, 53, 247, 233, 47, 166, 99, 21, 109, 203, 252, _
       19, 105, 93, 131, 101, 197, 29, 61, 173, 0, 158, 136, 31, 162, 137, 32, _
      131, 24, 3, 88, 88, 226, 48, 240, 136, 179, 29, 27, 41, 203, 141, 78, _
      197, 211, 43, 20, 179, 234, 212, 111, 180, 103, 10, 183, 44, 79, 211, 247, _
      207, 227, 177, 236, 174, 92, 147, 208, 243, 7, 24, 160, 94, 78, 132, 76, _
       36, 110, 114, 69, 147, 161, 219, 167, 196, 137, 57, 224, 17, 4, 16, 142, _
      202, 211, 201, 216, 9, 18, 70, 160, 10, 91, 42, 203, 72, 36, 111, 55, 32, _
    112, 248, 14, 228, 241, 210, 66, 153, 202, 171, 239, 246, 30, 165, 55, 31, 80, 152, 48, 158, 175, 96, 56, 86, 183, _
    170, 11, 132, 195, 84, 161, 125, 234, 81, 23, 249, 2, 68, 195, 52, 181, 244, 3, 45, 13, 158, 195, 240, 120, 196, _
    170, 105, 35, 62, 76, 23, 70, 52, 91, 116, 61, 167, 170, 210, 113, 170, 147, 96, 164, 27, 66, 114, 153, 113, 210, _
    119, 167, 91, 248, 227, 234, 12, 98, 152, 196, 53, 104, 48, 223, 19, 38, 108, 225, 124, 73, 93, 124, 105, 238, 28, _
    167, 123, 221, 66, 237, 181, 149, 37, 72, 178, 240, 239, 76, 225, 101, 22, 86, 26, 200, 98, 91, 117, 36, 68, 28, _
    1, 172, 201, 127, 183, 244, 199, 207, 171, 28, 56, 107, 20, 224, 143, 236, 92, 78, 207, 162, 13, 252, 68, 203, 11, _
    71, 239, 137, 125, 93, 148, 78, 202, 99, 120, 107, 145, 252, 128, 81, 110, 1, 120, 255, 144, 204, 197, 53, 162, 170, _
    127, 89, 146, 127, 140, 59, 105, 107, 234, 232, 81, 92, 9, 32, 182, 122, 183, 7, 231, 231, 21, 20, 98, 141, 216, _
    95, 103, 46, 161, 63, 57, 99, 113, 125, 208, 231, 81, 79, 72, 105, 36, 147, 1, 178, 76, 135, 222, 253, 189, 217, _
    43, 157, 15, 81, 254, 209, 205, 61, 14, 171, 214, 36, 223, 36, 72, 96, 190, 247, 160, 83, 46, 226, 230, 238, 202, _
    105, 18, 12, 136, 94, 68, 253, 74, 31, 223, 218, 225, 12, 74, 220, 177, 132, 108, 155, 225, 116, 130, 139, 219, 133, _
    211, 215, 70, 247, 168, 190, 229, 4, 127, 199, 103, 93, 71, 177, 247, 202, 186, 196, 73, 247, 22, 233, 203, 201, 1, _
    232, 21, 108, 45, 35, 64, 131, 249, 80, 211, 95, 186, 180, 223, 195, 15, 231, 72, 157, 152, 207, 218, 151, 152, 70, _
    13, 172, 234, 103, 225, 230, 210, 193, 105, 77, 108, 50, 86, 224, 18, 158, 56, 199, 181, 105, 123, 15, 36, 185, 36, _
    0, 85, 244, 143, 211, 73, 189, 121, 217, 192, 196, 57, 119, 173, 13, 178, 98, 107, 198, 176, 252, 225, 57, 225, 16, _
    189, 136, 195, 222, 137, 28, 144, 121, 172, 87, 191, 34, 38, 168, 140, 49, 61, 166, 9, 56, 132, 62, 68, 102, 141, _
    30, 64, 31, 104, 234, 25, 120, 94, 218, 127, 199, 57, 23, 193, 4, 4, 24, 186, 55, 70, 35, 51, 96, 205, 97, _
    36, 124, 221, 110, 126, 43, 226, 163, 246, 17, 73, 184, 163, 65, 80, 9, 172, 244, 216, 79, 78, 11, 152, 83, 51, _
    80, 19, 147, 2, 237, 191, 84, 104, 229, 83, 127, 55, 215, 147, 38, 166, 99, 171, 11, 205, 211, 228, 251, 31, 233, _
    228, 51, 37, 21, 59, 42, 95, 86, 252, 89, 147, 79, 178, 52, 234, 102, 190, 83, 128, 192, 172, 176, 226, 154, 56, _
    186, 49, 109, 78, 68, 59, 87, 64, 196, 25, 242, 238, 174, 90, 185, 205, 226, 97, 1, 50, 35, 119, 39, 89, 115, _
    211, 38, 9, 240, 235, 243, 255, 181, 210, 195, 73, 14, 196, 42, 212, 246, 29, 84, 44, 30, 207, 244, 244, 177, 89, _
    126, 188, 226, 208, 176, 25, 43, 230, 152, 110, 183, 124, 140, 81, 57, 86, 229, 123, 186, 7, 149, 66, 96, 159, 170, _
    238, 6, 73, 236, 201, 189, 136, 149, 63, 206, 140, 12, 71, 174, 129, 110, 120, 134, 118, 45, 181, 251, 232, 17, 205, _
    37, 52, 18, 180, 220, 24, 8, 235, 124, 177, 161, 14, 223, 53, 25, 101, 171, 86, 181, 25, 42, 133, 212, 247, 242, _
    241, 198, 168, 172, 151, 64, 174, 197, 254, 88, 169, 164, 74, 81, 87, 112, 58, 126, 33, 6, 201, 115, 71, 191, 195, _
    193, 179, 186, 236, 61, 166, 198, 104, 79, 178, 105, 135, 210, 80, 80, 21, 184, 229, 175, 150, 19, 44, 247, 11, 39, _
    168, 33, 212, 160, 100, 153, 245, 72, 76, 49, 182, 122, 58, 237, 154, 108, 102, 200, 207, 222, 106, 242, 126, 193, 2, _
    254, 235, 116, 1, 113, 85, 157, 51, 253, 225, 210, 187, 151, 109, 70, 133, 186, 75, 167, 251, 171, 116, 248, 132, 58, _
    34, 162, 179, 90, 154, 211, 128, 158, 197, 188, 198, 77, 66, 29, 80, 235, 36, 236, 157, 13, 39, 14, 167, 123, 96, _
    240, 25, 98, 207, 220, 230, 221, 241, 99, 171, 92, 185, 12, 48, 108, 240, 153, 72, 40, 82, 47, 42, 39, 236, 147, _
    242, 16, 175, 17, 122, 40, 156, 21, 244, 243, 47, 159, 70, 28, 100, 96, 156, 92, 211, 49, 167, 38, 48, 136, 76, _
    203, 138, 157, 120, 146, 149, 144, 235, 234, 149, 242, 110, 108, 250, 33, 250, 217, 215, 235, 74, 157, 25, 30, 252, 94, _
    119, 180, 141, 92, 0, 255, 27, 17, 76, 203, 227, 204, 135, 34, 113, 196, 138, 36, 130, 30, 253, 166, 60, 189, 84, _
    89, 9, 235, 212, 225, 221, 18, 39, 87, 203, 3, 41, 32, 145, 98, 165, 31, 118, 105, 127, 132, 63, 161, 70, 220, _
    138, 115, 198, 96, 236, 31, 36, 45, 121, 176, 28, 188, 52, 92, 138, 70, 165, 136, 60, 208, 124, 172, 71, 250, 244, _
    230, 181, 140, 133, 202, 228, 18, 67, 25, 80, 187, 248, 223, 95, 100, 48, 218, 109, 130, 136, 93, 155, 178, 175, 167, _
    15, 253, 157, 237, 205, 172, 3, 26, 223, 68, 243, 57, 111, 168, 151, 1, 78, 0, 181, 15, 69, 103, 108, 144, 35, _
    137, 166, 247, 124, 174, 45, 117, 29, 150, 200, 52, 205, 37, 48, 248, 231, 58, 147, 189, 2, 26, 101, 106, 209, 239, _
    217, 20, 85, 17, 23, 90, 242, 179, 75, 109, 246, 32, 49, 67, 149, 53, 191, 209, 100, 242, 8, 238, 166, 13, 1, _
    203, 52, 123, 6, 170, 193, 254, 230, 208, 67, 37, 210, 46, 112, 146, 248, 59, 37, 121, 198, 80, 79, 10, 87, 75, _
    12, 83, 245, 228, 56, 64, 146, 149, 221, 171, 178, 45, 26, 165, 163, 213, 139, 169, 130, 231, 18, 57, 120, 196, 195, _
    127, 4, 35, 100, 214, 21, 65, 180, 138, 149, 194, 107, 90, 7, 24, 11, 133, 202, 244, 36, 61, 164, 130, 105, 163, _
   170, 154, 27, 53, 36, 130, 57, 187, 128, 179, 95, 190, 50, 39, 83, 105, 9, 148, 185, 172, 17, 157, 160, 241, 28, _
    76, 216, 202, 6, 81, 194, 130, 188, 223, 147, 196, 63, 153, 211, 121, 124, 137, 243, 119, 68, 149, 151, 36, 191, 126, _
    26, 167, 154, 164, 174, 220, 176, 9, 238, 13, 55, 97, 85, 215, 85, 82, 211, 161, 82, 73, 79, 202, 109, 127, 118, _
    244, 255, 33, 108, 247, 240, 13, 247, 137, 117, 211, 189, 120, 187, 161, 177, 17, 127, 90, 5, 237, 145, 57, 136, 6, _
    136, 218, 84, 82, 183, 248, 138, 228, 51, 197, 30, 252, 202, 38, 226, 117, 33, 193, 16, 122, 95, 227, 50, 204, 167, _
    57, 178, 31, 189, 1, 208, 124, 100, 246, 99, 187, 56, 113, 57, 234, 242, 8, 137, 4, 167, 53, 91, 230, 59, 57, _
    16, 14, 103, 68, 150, 120, 131, 5, 4, 207, 56, 146, 250, 112, 29, 212, 53, 72, 183, 72, 76, 21, 51, 173, 15, _
    173, 85, 96, 129, 86, 34, 16, 210, 129, 60, 66, 190, 93, 241, 77, 214, 52, 179, 21, 241, 214, 181, 188, 7, 46, _
    66, 67, 109, 108, 157, 86, 188, 161, 83}

#End Region

    Const BINFileName As String = "ScannerConfig.bin"

    Const ConfigBINPath As String = ".\ConfigBIN"
    Const ConfigXMLPath As String = ".\ConfigXML"
    Const ConfigImagesPath As String = ".\Images"

    ''' <summary>
    ''' Goes through each carrier generating the the BIN config files
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()

        Console.WriteLine()

        Dim ConfigBINDir As IO.DirectoryInfo = Nothing
        Dim ConfigXMLDir As IO.DirectoryInfo = Nothing
        Dim ConfigImagesDir As IO.DirectoryInfo = Nothing

        If Not IO.Directory.Exists(ConfigBINPath) Then IO.Directory.CreateDirectory(ConfigBINPath)
        If Not IO.Directory.Exists(ConfigXMLPath) Then IO.Directory.CreateDirectory(ConfigXMLPath)
        If Not IO.Directory.Exists(ConfigImagesPath) Then IO.Directory.CreateDirectory(ConfigImagesPath)

        ConfigBINDir = New IO.DirectoryInfo(ConfigBINPath)
        ConfigXMLDir = New IO.DirectoryInfo(ConfigXMLPath)
        ConfigImagesDir = New IO.DirectoryInfo(ConfigImagesPath)

        Dim BB As BinBuilder
        Dim XMLDirs() As IO.DirectoryInfo = ConfigXMLDir.GetDirectories()
        Dim XMLDir As IO.DirectoryInfo = Nothing
        Dim ImagesDir As IO.DirectoryInfo = Nothing
        Dim BINDir As IO.DirectoryInfo = Nothing

        Dim XMLFile As IO.FileInfo = Nothing
        Dim AdminImageFile As IO.FileInfo = Nothing
        Dim InitImageFile As IO.FileInfo = Nothing
        Dim ScanImageFile As IO.FileInfo = Nothing
        Dim BINFile As IO.FileInfo = Nothing

        Dim Files() As IO.FileInfo
        For Each XMLDir In XMLDirs
            If ConfigImagesDir.GetDirectories(XMLDir.Name).Length = 1 Then
                ImagesDir = ConfigImagesDir.GetDirectories(XMLDir.Name)(0)
            Else
                Console.WriteLine("No images directory for carrier " & XMLDir.Name & ", skipping.")
                Continue For
            End If

            If ConfigBINDir.GetDirectories(XMLDir.Name).Length = 1 Then
                BINDir = ConfigBINDir.GetDirectories(XMLDir.Name)(0)
            Else
                IO.Directory.CreateDirectory(ConfigBINDir.FullName & "\" & XMLDir.Name)
                BINDir = ConfigBINDir.GetDirectories(XMLDir.Name)(0)
            End If

            Files = XMLDir.GetFiles("*Config*.xml")
            If Files.Length = 1 Then
                XMLFile = Files(0)
            ElseIf Files.Length > 1 Then
                Console.WriteLine("WARNING: More than one config file found for carrier " & XMLDir.Name & ", using first one.")
                XMLFile = Files(0)
            Else
                Console.WriteLine("No ""*Config*.xml"" for carrier " & XMLDir.Name & ", skipping.")
                Continue For
            End If

            Files = ImagesDir.GetFiles("*AdminLogo.bmp")
            If Files.Length = 1 Then
                AdminImageFile = Files(0)
            ElseIf Files.Length > 1 Then
                Console.WriteLine("WARNING: More than one admin logo file found for carrier " & XMLDir.Name & ", using first one.")
                AdminImageFile = Files(0)
            Else
                Console.WriteLine("No ""*AdminLogo.bmp"" for carrier " & XMLDir.Name & ", skipping.")
                Continue For
            End If

            Files = ImagesDir.GetFiles("*InitLogo.bmp")
            If Files.Length = 1 Then
                InitImageFile = Files(0)
            ElseIf Files.Length > 1 Then
                Console.WriteLine("WARNING: More than one init logo file found for carrier " & XMLDir.Name & ", using first one.")
                InitImageFile = Files(0)
            Else
                Console.WriteLine("No ""*InitLogo.bmp"" for carrier " & XMLDir.Name & ", skipping.")
                Continue For
            End If

            Files = ImagesDir.GetFiles("*ScanLogo.bmp")
            If Files.Length = 1 Then
                ScanImageFile = Files(0)
            ElseIf Files.Length > 1 Then
                Console.WriteLine("WARNING: More than one scan logo file found for carrier " & XMLDir.Name & ", using first one.")
                ScanImageFile = Files(0)
            Else
                Console.WriteLine("No ""*ScanLogo.bmp"" for carrier " & XMLDir.Name & ", skipping.")
                Continue For
            End If

            Try
                If Not IO.File.Exists(BINDir.FullName & "\" & BINFileName) Then
                    IO.File.Create(BINDir.FullName & "\" & BINFileName).Close()
                End If
                BINFile = New IO.FileInfo(BINDir.FullName & "\" & BINFileName)
            Catch ex As Exception
                Console.WriteLine("Unable to create/open the file """ & BINFileName & """ for carrier " & XMLDir.Name & ", skipping.")
                Continue For
            End Try

            '' Parse XML
            Dim XMLconfig As New XMLer()
            If Not XMLconfig.Load(XMLFile) Then
                Console.WriteLine("ERROR: """ & XMLFile.Name & """ for carrier " & XMLDir.Name & " can't be loaded, please fix this.")
                Console.WriteLine("SKIPPING " & XMLDir.Name & ".")
                Continue For
            End If

            If Not XMLconfig.Validate() Then
                Console.WriteLine("ERROR: """ & XMLFile.Name & """ for carrier " & XMLDir.Name & " contains invalid XML, please fix this.")
                Console.WriteLine("SKIPPING " & XMLDir.Name & ".")
                Continue For
            End If

            '' Get version number out
            Dim BINVer As String = XMLconfig.GetVersionNumber()
            VersionWriter.Write(New IO.DirectoryInfo(BINFile.DirectoryName), BINVer)


            BB = New BinBuilder(XMLDir.Name, XMLFile, InitImageFile, AdminImageFile, ScanImageFile, BINFile)
            If BB.Generate() Then
                Console.WriteLine("""" & BINFileName & """ generated for carrier " & XMLDir.Name)
            End If
        Next

    End Sub


End Module