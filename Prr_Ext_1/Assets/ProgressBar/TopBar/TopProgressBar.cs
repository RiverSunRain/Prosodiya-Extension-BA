using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Prosodiya
{
    public class TopProgressBar : MonoBehaviourSingleton<TopProgressBar>
    {
        public GameObject InnerFill;
        public GameObject SkewedSeperator;
        public GameObject ProgressBarFrame;
        public AudioClip UpdateSound;

        private int _totalExerciseCount;
        private float _sepWidth;
        private int _tasksCompletedCnt = -1;
        public float _previousXpos = 0;
        private float _sepSpacing;

        #region For external calls

        /// <summary>
        /// Rrepare the TopProgressBar
        /// </summary>
        /// <param name="numberOfTasks"></param>
        public void Prepare(int numberOfTasks)
        {
            _totalExerciseCount = numberOfTasks;
            AddSeperators(_totalExerciseCount);
            UpdateProgress();
        }

        public void PrepareSpecificProgress(int numberOfFinishedTasks, int numberOfTotalTasks)
        {
            _totalExerciseCount = numberOfTotalTasks;
            AddSeperators(_totalExerciseCount, numberOfFinishedTasks);
            InnerFill.GetComponent<Image>().enabled = true;
            FillProgBar(_previousXpos);
        }

        /// <summary>
        /// Enable or Disable Progress Bar GameObject
        /// </summary>
        /// <param name="show"></param>
        public void ShowProgressBar(bool show)
        {
            gameObject.SetActive(show);
        }
        
        /// <summary>
        /// Reset counter
        /// </summary>
        public void Cleanup()
        {
            _tasksCompletedCnt = -1;
        }

        /// <summary>
        /// Updates the progressbar with its filled elements
        /// </summary>
        public void UpdateProgress()
        {
            _tasksCompletedCnt++;

            //as long as there are still some exercises to learn
            if (_tasksCompletedCnt > 0 && _tasksCompletedCnt < _totalExerciseCount)
            {
                InnerFill.GetComponent<Image>().enabled = true;

                //Tween between the old position and the new one
                FillProgBar(ProgressBarFrame.GetComponentsInChildren<Image>()[_tasksCompletedCnt].gameObject.GetComponent<RectTransform>().anchoredPosition.x);

                //Save the old position to start from it next time
                _previousXpos = ProgressBarFrame.GetComponentsInChildren<Image>()[_tasksCompletedCnt].gameObject.GetComponent<RectTransform>().anchoredPosition.x;
            }
            //for the last exercise
            else if (_tasksCompletedCnt >= _totalExerciseCount)
            {
                //Tween between the old position and the pos of the last Seperator
                FillProgBar(ProgressBarFrame.GetComponent<RectTransform>().sizeDelta.x);
            }
            //at beginning
            else
            {
                InnerFill.GetComponent<Image>().enabled = false;
            }
        }

        #endregion

        #region internal calls

        private void AddSeperators(int numberOfExercises, int numberOfFinishedTasks = -1)
        {
            _sepWidth = SkewedSeperator.GetComponent<RectTransform>().sizeDelta.x;

            var totalSize = ProgressBarFrame.GetComponent<RectTransform>().sizeDelta;
            // Calculate the spacing for the separators.
            _sepSpacing = (totalSize.x) / (float)(numberOfExercises) - _sepWidth;
            ProgressBarFrame.GetComponent<HorizontalLayoutGroup>().spacing = _sepSpacing;
            
            // Insert separators. +1 is added to put one seperator in the end
            for (int i = 0; i < numberOfExercises; i++)
            {
                var go = Instantiate(SkewedSeperator);
                go.transform.SetParent(ProgressBarFrame.transform, false);
                //merken, wann separator gehittet wird und ihn als prevxpos merken
                if (numberOfFinishedTasks == i)
                {
                    _previousXpos = (_sepWidth + _sepSpacing) * i;
                }

                // Make the first and last separator invisible. It's just there for shifting all other separators accordingly and making the innerFill fit till the end.
                if (i == 0 || i == numberOfExercises)
                {
                    go.GetComponent<CanvasRenderer>().SetAlpha(0);
                }
            }
        }

        private void FillProgBar(float targetPos, float time = 1f)
        {
            LeanTween.value(InnerFill, TweenProgress, _previousXpos, targetPos, time).setEase(LeanTweenType.easeInOutSine);
            this.GetComponent<AudioSource>().PlayOneShot(UpdateSound); 
        }

        private void TweenProgress(float f)
        {
            // 14 is the offset from the GO far left (and maybe right, idk). Anyways, -14 works fine.
            //Set the width of the filler on each tween-update
            InnerFill.GetComponent<RectTransform>().sizeDelta = new Vector2(f + _sepWidth, InnerFill.GetComponent<RectTransform>().sizeDelta.y);
        }

        #endregion
    }
}